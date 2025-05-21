using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mynewapp.Models;
using Mynewapp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mynewapp.Pages.Items
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IItemService _itemService;

        public IndexModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IList<Item> Items { get; set; }

        public async Task OnGetAsync()
        {
            Items = await _itemService.GetAllItemsAsync();
        }
    }
}
