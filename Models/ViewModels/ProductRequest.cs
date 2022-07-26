using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.ViewModels
{
    public class ProductRequest
    {
        //Te sugiero que le quites los guiones bajos a los nombres y utilices PascalCase para los nombres de las Propiedades ayuda a mejorar a la lectura, el "Product_id"
        //se refiere al id del producto
        public int Product_Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        //aqui le falta la restricción de la edad que tiene la tabla Products que debe ser mayor a cero y menor o igual a 100
        public int AgeRestriction { get; set; }
        //aqui le falta la restriccion del precio que tiene la tabla Products que debe ser mayor a cero y menor o igual a 1000
        public decimal Price { get; set; }
        //Te sugiero que le quites los guiones bajos a los nombres y utilices PascalCase para los nombres de las Propiedades ayuda a mejorar a la lectura, el "company_id"
        //se refiere al id de la compañía
        public int Company_Id { get; set; }
    }
}
