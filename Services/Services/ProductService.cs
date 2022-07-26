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
            var product = _db.Products.Find(model.Product_Id);

            product.Name = model.Name;
            product.Description = model.Description;
            product.AgeRestriction = model.AgeRestriction;
            product.Price = model.Price;
            product.Company_Id = model.Company_Id;

            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public object Show()
        {
            var query = from product in _db.Products
                        orderby product.Product_Id descending
                        join company in _db.Companies on product.Company_Id equals company.Id
                        select new
                        {
                            product.Product_Id,
                            product.Name,
                            product.Description,
                            product.AgeRestriction,
                            company.Id,
                            company.Company_Name,
                            product.Price
                        };
            return query;
        }

    }
}
