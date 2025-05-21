using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mynewapp.Models;
using Mynewapp.Services;
using System.Threading.Tasks;

namespace Mynewapp.Pages.Items
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IItemService _itemService;

        public DetailsModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _itemService.GetItemByIdAsync(id.Value);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
