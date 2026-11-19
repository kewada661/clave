using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using clave.Models;

namespace clave.Pages.UserPages;

public class EditModel : PageModel
{
    private readonly claveContext _context;

    public EditModel(claveContext context)
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
        ClaveUser = user;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(User).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(ClaveUser.Id!))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool UserExists(int id)
    {
        return _context.User.Any(e => e.Id == id);
    }
}
