using System.ComponentModel.DataAnnotations;

namespace Vasilcan_Darius_Gheorghe_Lab2.Models;

public class Member
{
    public int ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }

    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }

    [Display(Name = "Full Name")]
    public string FullName => $"{FirstName} {LastName}".Trim();

    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
}
