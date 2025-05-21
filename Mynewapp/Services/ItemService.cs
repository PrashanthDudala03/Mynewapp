using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Mynewapp.Data;
using Mynewapp.Hubs;
using Mynewapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mynewapp.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(int id);
        Task<Item> CreateItemAsync(Item item, string userId);
        Task<Item> UpdateItemAsync(Item item, string userId);
        Task<bool> DeleteItemAsync(int id);
    }
    
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ItemHub> _hubContext;
        
        public ItemService(ApplicationDbContext context, IHubContext<ItemHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        
        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }
        
        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }
        
        public async Task<Item> CreateItemAsync(Item item, string userId)
        {
            item.CreatedDate = DateTime.Now;
            item.LastModified = DateTime.Now;
            item.CreatedBy = userId;
            
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            
            // Notify clients about the new item
            await _hubContext.Clients.All.SendAsync("ReceiveItemCreated", item);
            
            return item;
        }
        
        public async Task<Item> UpdateItemAsync(Item item, string userId)
        {
            var existingItem = await _context.Items.FindAsync(item.ID);
            
            if (existingItem == null)
                return null;
                
            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.IsActive = item.IsActive;
            existingItem.LastModified = DateTime.Now;
            
            await _context.SaveChangesAsync();
            
            // Notify clients about the updated item
            await _hubContext.Clients.All.SendAsync("ReceiveItemUpdate", existingItem);
            
            return existingItem;
        }
        
        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            
            if (item == null)
                return false;
                
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            
            // Notify clients about the deleted item
            await _hubContext.Clients.All.SendAsync("ReceiveItemDeleted", id);
            
            return true;
        }
    }
}
