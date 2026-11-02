using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vasilcan_Darius_Gheorghe_Lab2.Models;

namespace Vasilcan_Darius_Gheorghe_Lab2.Pages.Members;

public class IndexModel : PageModel
{
    private readonly Vasilcan_Darius_Gheorghe_Lab2Context _context;
    public IndexModel(Vasilcan_Darius_Gheorghe_Lab2Context context) => _context = context;
    public IList<Member> Member { get; private set; } = new List<Member>();
    public async Task OnGetAsync() => Member = await _context.Member.OrderBy(member => member.LastName).ThenBy(member => member.FirstName).ToListAsync();
}
