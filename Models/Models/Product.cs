
using System.Text.Json.Serialization;

namespace DB.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int AgeRestriction { get; set; }

        public decimal Price { get; set; } 

        public int CompanyId { get; set; }

        [JsonIgnore]
        public Company Company { get; set; } 
    }
}
