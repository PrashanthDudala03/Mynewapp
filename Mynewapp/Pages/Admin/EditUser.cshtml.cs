using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mynewapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class EditUserModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EditUserModel(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public string UserId { get; set; }

        public string UserName { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        public bool EmailConfirmed { get; set; }

        [BindProperty]
        public List<string> SelectedRoles { get; set; } = new List<string>();

        public List<string> UserRoles { get; set; } = new List<string>();
        public List<string> AllRoles { get; set; } = new List<string>();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            UserId = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            EmailConfirmed = user.EmailConfirmed;
            UserRoles = (await _userManager.GetRolesAsync(user)).ToList();
            AllRoles = _roleManager.Roles.Select(r => r.Name).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                AllRoles = _roleManager.Roles.Select(r => r.Name).ToList();
                return Page();
            }

            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }

            UserName = user.UserName;
            
            // Update email and email confirmed status
            user.Email = Email;
            user.EmailConfirmed = EmailConfirmed;
            await _userManager.UpdateAsync(user);
            
            // Update roles
            var currentRoles = await _userManager.GetRolesAsync(user);
            
            // Remove roles that are no longer selected
            var rolesToRemove = currentRoles.Where(r => !SelectedRoles.Contains(r)).ToList();
            if (rolesToRemove.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
            }
            
            // Add newly selected roles
            var rolesToAdd = SelectedRoles.Where(r => !currentRoles.Contains(r)).ToList();
            if (rolesToAdd.Any())
            {
                await _userManager.AddToRolesAsync(user, rolesToAdd);
            }

            return RedirectToPage("./Users");
        }
    }
}
