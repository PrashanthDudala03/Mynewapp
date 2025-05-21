using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mynewapp.Models;
using Mynewapp.Services;
using System;
using System.Threading.Tasks;

namespace Mynewapp.Pages.Items
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IItemService _itemService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(IItemService itemService, UserManager<ApplicationUser> userManager)
        {
            _itemService = itemService;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            Item = new Item { CreatedDate = DateTime.Now };
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            await _itemService.CreateItemAsync(Item, user?.Id);

            return RedirectToPage("./Index");
        }
    }
}
