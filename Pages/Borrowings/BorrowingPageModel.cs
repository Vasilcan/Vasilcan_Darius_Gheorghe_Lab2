using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Vasilcan_Darius_Gheorghe_Lab2.Pages.Borrowings;

[Authorize]
public abstract class BorrowingPageModel : PageModel
{
    protected readonly Vasilcan_Darius_Gheorghe_Lab2Context Context;
    protected BorrowingPageModel(Vasilcan_Darius_Gheorghe_Lab2Context context) => Context = context;

    protected async Task PopulateSelectionsAsync(object? selectedBook = null, object? selectedMember = null)
    {
        var books = await Context.Book.Include(book => book.Author)
            .OrderBy(book => book.Title)
            .Select(book => new { book.ID, Name = book.Title + " - " + (book.Author == null ? "" : book.Author.LastName + " " + book.Author.FirstName) })
            .ToListAsync();
        BookList = new SelectList(books, "ID", "Name", selectedBook);
        MemberList = new SelectList(await Context.Member.OrderBy(member => member.LastName).ThenBy(member => member.FirstName).ToListAsync(), "ID", "FullName", selectedMember);
    }

    public SelectList BookList { get; private set; } = default!;
    public SelectList MemberList { get; private set; } = default!;
}
