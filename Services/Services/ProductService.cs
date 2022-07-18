using DB.Context;
using DB.Models;
using DB.ViewModels;
using Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public void Add(ProductRequest model)
        {
            var product = new Product();

            product.Name = model.Name;
            product.Description = model.Description;
            product.AgeRestriction = model.AgeRestriction;
            product.Price = model.Price;
            product.Company_Id = model.Company_Id;
            _db.Products.Add(product);

            _db.SaveChanges();
        }

        public void Eliminate(int id)
        {
            var product = _db.Products.Find(id);
            _db.Remove(product);
            _db.SaveChanges();
        }

        public void Edit(ProductRequest model)
        {
            var product = _db.Products.Find(model.Id);

            product.Name = model.Name;
            product.Description = model.Description;
            product.AgeRestriction = model.AgeRestriction;
            product.Price = model.Price;

            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public List<Product> Show()
        {
            var lst = _db.Products.ToList();
            return lst;
        }
    }
}
