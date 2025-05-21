using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mynewapp.Models;
using Mynewapp.Services;
using System.Threading.Tasks;

namespace Mynewapp.Pages.Items
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IItemService _itemService;

        public DeleteModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _itemService.DeleteItemAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
