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

        //Te sugiero que le quites los guiones bajos a los nombres y utilices PascalCase para los nombres de las Propiedades ayuda a mejorar a la lectura, tambien se entiende que por ser una entidad company, el "companyname"
        //se refiere al nombre de la compañía, name debería bastar
        public string Company_Name { get; set; }

        public List<Product> Product { get; set; }
    }
}
