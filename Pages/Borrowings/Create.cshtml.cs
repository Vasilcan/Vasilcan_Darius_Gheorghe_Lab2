using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vasilcan_Darius_Gheorghe_Lab2.Models;

namespace Vasilcan_Darius_Gheorghe_Lab2.Pages.Borrowings;

public class CreateModel : BorrowingPageModel
{
    public CreateModel(Vasilcan_Darius_Gheorghe_Lab2Context context) : base(context) { }
    [BindProperty] public Borrowing Borrowing { get; set; } = new() { ReturnDate = DateTime.Today.AddDays(14) };
    public async Task OnGetAsync() => await PopulateSelectionsAsync();
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) { await PopulateSelectionsAsync(Borrowing.BookID, Borrowing.MemberID); return Page(); }
        Context.Borrowing.Add(Borrowing); await Context.SaveChangesAsync(); return RedirectToPage("Index");
    }
}
