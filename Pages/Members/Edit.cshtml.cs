using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vasilcan_Darius_Gheorghe_Lab2.Models;

namespace Vasilcan_Darius_Gheorghe_Lab2.Pages.Members;

public class EditModel : PageModel
{
    private readonly Vasilcan_Darius_Gheorghe_Lab2Context _context;
    public EditModel(Vasilcan_Darius_Gheorghe_Lab2Context context) => _context = context;
    [BindProperty] public Member Member { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null || (Member = await _context.Member.FindAsync(id)) is null) return NotFound();
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        _context.Attach(Member).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
