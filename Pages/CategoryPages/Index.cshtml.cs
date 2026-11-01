using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vasilcan_Darius_Gheorghe_Lab2.Models;

namespace Vasilcan_Darius_Gheorghe_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Vasilcan_Darius_Gheorghe_Lab2Context _context;

    public IndexModel(Vasilcan_Darius_Gheorghe_Lab2Context context)
    {
        _context = context;
    }

    public CategoryData CategoryData { get; set; } = default!;
    public int CategoryID { get; set; }

    public async Task OnGetAsync(int? id)
    {
        CategoryData = new CategoryData
        {
            Categories = await _context.Category
                .Include(category => category.BookCategories!)
                    .ThenInclude(bookCategory => bookCategory.Book)
                        .ThenInclude(book => book.Author)
                .AsNoTracking()
                .OrderBy(category => category.CategoryName)
                .ToListAsync()
        };

        if (id is not null)
        {
            CategoryID = id.Value;
            var category = CategoryData.Categories.Single(category => category.ID == id.Value);
            CategoryData.Books = category.BookCategories!
                .Select(bookCategory => bookCategory.Book)
                .OrderBy(book => book.Title)
                .ToList();
        }
    }
}
