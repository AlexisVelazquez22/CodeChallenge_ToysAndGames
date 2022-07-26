using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.ViewModels
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        //aqui le falta la restricción de la edad que tiene la tabla Products que debe ser mayor a cero y menor o igual a 100
        public int AgeRestriction { get; set; }
        //aqui le falta la restriccion del precio que tiene la tabla Products que debe ser mayor a cero y menor o igual a 1000
        public decimal Price { get; set; }
        public int Company_Id { get; set; }
    }
}
