using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vasilcan_Darius_Gheorghe_Lab2.Models;

namespace Vasilcan_Darius_Gheorghe_Lab2.Pages.Borrowings;

public class IndexModel : PageModel
{
    private readonly Vasilcan_Darius_Gheorghe_Lab2Context _context;
    public IndexModel(Vasilcan_Darius_Gheorghe_Lab2Context context) => _context = context;
    public IList<Borrowing> Borrowing { get; private set; } = new List<Borrowing>();

    public async Task OnGetAsync() => Borrowing = await _context.Borrowing
        .Include(borrowing => borrowing.Member)
        .Include(borrowing => borrowing.Book).ThenInclude(book => book!.Author)
        .OrderBy(borrowing => borrowing.ReturnDate)
        .ToListAsync();
}
