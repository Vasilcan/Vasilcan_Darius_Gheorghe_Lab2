using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vasilcan_Darius_Gheorghe_Lab2.Models;

namespace Vasilcan_Darius-Gheorghe_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Vasilcan_Darius_Gheorghe_Lab2Context _context;

    public IndexModel(Vasilcan_Darius_Gheorghe_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Book = await _context.Book.ToListAsync();
    }
}
