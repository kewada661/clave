using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using clave.Models;

namespace clave.Pages.UserPages;

public class UsersIndexModel : PageModel
{
    private readonly claveContext _context;

    public UsersIndexModel(claveContext context)
    {
        _context = context;
    }

    public IList<User> Users { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Users = await _context.User.ToListAsync();
    }
}
