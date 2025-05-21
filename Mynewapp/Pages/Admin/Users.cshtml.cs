using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mynewapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class UsersModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersModel(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public class UserWithRoles
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public bool EmailConfirmed { get; set; }
            public List<string> Roles { get; set; } = new List<string>();
        }

        public List<UserWithRoles> Users { get; set; } = new List<UserWithRoles>();

        public async Task OnGetAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            
            foreach (var user in users)
            {
                var userWithRoles = new UserWithRoles
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    Roles = (await _userManager.GetRolesAsync(user)).ToList()
                };
                
                Users.Add(userWithRoles);
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
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

            // Don't allow deleting the current user
            if (user.UserName == User.Identity.Name)
            {
                return RedirectToPage();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            return RedirectToPage();
        }
    }
}
