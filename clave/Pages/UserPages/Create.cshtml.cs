using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using clave.Models;

namespace clave.Pages.UserPages;

public class CreateModel : PageModel
{
    private readonly claveContext _context;

    public CreateModel(claveContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public User ClaveUser { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.User.Add(ClaveUser);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
