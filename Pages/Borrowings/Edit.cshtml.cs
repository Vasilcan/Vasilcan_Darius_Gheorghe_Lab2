using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vasilcan_Darius_Gheorghe_Lab2.Models;

namespace Vasilcan_Darius_Gheorghe_Lab2.Pages.Borrowings;

public class EditModel : BorrowingPageModel
{
    public EditModel(Vasilcan_Darius_Gheorghe_Lab2Context context) : base(context) { }
    [BindProperty] public Borrowing Borrowing { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null || (Borrowing = await Context.Borrowing.FindAsync(id)) is null) return NotFound();
        await PopulateSelectionsAsync(Borrowing.BookID, Borrowing.MemberID); return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) { await PopulateSelectionsAsync(Borrowing.BookID, Borrowing.MemberID); return Page(); }
        Context.Attach(Borrowing).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        try { await Context.SaveChangesAsync(); } catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException) { if (!Context.Borrowing.Any(item => item.ID == Borrowing.ID)) return NotFound(); throw; }
        return RedirectToPage("Index");
    }
}
