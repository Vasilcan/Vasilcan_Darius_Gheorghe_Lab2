using Microsoft.EntityFrameworkCore;

public class Vasilcan_Darius_Gheorghe_Lab2Context(DbContextOptions<Vasilcan_Darius_Gheorghe_Lab2Context> options) : DbContext(options)
{
    public DbSet<Vasilcan_Darius_Gheorghe_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Vasilcan_Darius_Gheorghe_Lab2.Models.Publisher> Publisher { get; set; } = default!;

    public DbSet<Vasilcan_Darius_Gheorghe_Lab2.Models.Author> Author { get; set; } = default!;

    public DbSet<Vasilcan_Darius_Gheorghe_Lab2.Models.Category> Category { get; set; } = default!;
}
