using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class ProductCompanyDTO
    {
        public int ProductId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int AgeRestriction { get; set; }

        public int CompanyId { get; set; }

        public string? Title { get; set; }

        public decimal Price { get; set; }
    }
}
