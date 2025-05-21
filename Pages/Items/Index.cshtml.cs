using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mynewapp.Data;
using Mynewapp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mynewapp.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Items { get; set; }

        public async Task OnGetAsync()
        {
            Items = await _context.Items.ToListAsync();
        }
    }
}
