using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Product
    {
        public int Product_Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int AgeRestriction { get; set; }

        public decimal Price { get; set; }

        public int Company_Id { get; set; }
        [Required]
        public Company Company { get; set; } 
    }
}
