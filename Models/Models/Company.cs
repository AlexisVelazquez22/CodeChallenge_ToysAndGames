using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Company_Name { get; set; }

        public List<Product> Product { get; set; }
    }
}
