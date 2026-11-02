using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Vasilcan_Darius_Gheorghe_Lab2.Models;

namespace Vasilcan_Darius_Gheorghe_Lab2.Pages.Borrowings;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly Vasilcan_Darius_Gheorghe_Lab2Context _context;
    public DeleteModel(Vasilcan_Darius_Gheorghe_Lab2Context context) => _context = context;
    [BindProperty] public Borrowing Borrowing { get; private set; } = default!;
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null) return NotFound();
        Borrowing = await _context.Borrowing.Include(item => item.Member).Include(item => item.Book).ThenInclude(book => book!.Author).FirstOrDefaultAsync(item => item.ID == id);
        return Borrowing is null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null) return NotFound();
        var borrowing = await _context.Borrowing.FindAsync(id);
        if (borrowing is not null) { _context.Borrowing.Remove(borrowing); await _context.SaveChangesAsync(); }
        return RedirectToPage("Index");
    }
}
