
namespace DB.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string? Title { get; set; }

        public List<Product> Product { get; set; }
    }
}
