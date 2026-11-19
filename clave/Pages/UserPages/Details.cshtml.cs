using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using clave.Models;

namespace clave.Pages.UserPages;

public class DetailsModel : PageModel
{
    private readonly claveContext _context;
    public DetailsModel(claveContext context)
    {
        _context = context;
    }

    public User ClaveUser { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
        if (user is null)
        {
            return NotFound();
        }
        else
        {
            ClaveUser = user;
        }

        return Page();
    }
}
