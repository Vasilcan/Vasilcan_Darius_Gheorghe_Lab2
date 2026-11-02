using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vasilcan_Darius_Gheorghe_Lab2.Models;

namespace Vasilcan_Darius_Gheorghe_Lab2.Pages.Members;

public class CreateModel : PageModel
{
    private readonly Vasilcan_Darius_Gheorghe_Lab2Context _context;
    public CreateModel(Vasilcan_Darius_Gheorghe_Lab2Context context) => _context = context;
    [BindProperty] public Member Member { get; set; } = new();
    public void OnGet() { }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        _context.Member.Add(Member); await _context.SaveChangesAsync(); return RedirectToPage("Index");
    }
}
