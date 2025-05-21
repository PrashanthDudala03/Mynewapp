using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mynewapp.Models;
using Mynewapp.Services;
using System.Threading.Tasks;

namespace Mynewapp.Pages.Items
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IItemService _itemService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditModel(IItemService itemService, UserManager<ApplicationUser> userManager)
        {
            _itemService = itemService;
            _userManager = userManager;
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            await _itemService.UpdateItemAsync(Item, user?.Id);

            return RedirectToPage("./Index");
        }
    }
}
