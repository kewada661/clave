using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using clave.Models;

namespace clave.Pages.UserPages;

public class DeleteModel : PageModel
{
    private readonly claveContext _context;

    public DeleteModel(claveContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(string? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var user = await _context.User.FindAsync(id);
        if (user != null)
        {
            ClaveUser = user;
            _context.User.Remove(ClaveUser);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
