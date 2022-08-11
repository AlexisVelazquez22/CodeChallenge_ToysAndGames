
using System.Text.Json.Serialization;

namespace DB.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string? Title { get; set; }

        [JsonIgnore]
        public List<Product> Product { get; set; }
    }
}
