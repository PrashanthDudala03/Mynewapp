using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mynewapp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mynewapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public int UserCount { get; set; }
        public int ItemCount { get; set; }
        public int ActiveItemCount { get; set; }

        public async Task OnGetAsync()
        {
            UserCount = await _userManager.Users.CountAsync();
            ItemCount = await _context.Items.CountAsync();
            ActiveItemCount = await _context.Items.Where(i => i.IsActive).CountAsync();
        }
    }
}
