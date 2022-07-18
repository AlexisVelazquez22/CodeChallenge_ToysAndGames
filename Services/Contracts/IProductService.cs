using DB.Models;
using DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductService
    {
        public List<Product> Show();
        public void Add(ProductRequest model);
        public void Edit(ProductRequest model);
        public void Eliminate(int id);
    }
}
