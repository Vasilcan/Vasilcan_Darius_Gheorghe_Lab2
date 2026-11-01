namespace Vasilcan_Darius_Gheorghe_Lab2.Models
{
    public class CategoryData
    {
        public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();
        public IEnumerable<Book>? Books { get; set; }
    }
}
