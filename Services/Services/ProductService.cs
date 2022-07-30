﻿using DB.Context;
using DB.Models;
using DB.ViewModels;
using Services.Contracts;
using AutoMapper;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Product> Add(ProductRequest model)
        {
            var product = new Product();

            product = _mapper.Map<Product>(model);
            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Delete(int id)
        {
            var product = _db.Products.Find(id);

            if (product == null)
                return false;

            _db.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Product> Edit(ProductRequest model, int id)
        {
            var product = _db.Products.Find(id);

            if (product != null)
            {
                product = _mapper.Map<Product>(model);
                product.ProductId = id;
                _db.ChangeTracker.Clear();
                _db.Update(product);
                await _db.SaveChangesAsync();
            }

            return product;
        }

        public IEnumerable<dynamic> Get()
        {
            var query = from product in _db.Products
                        orderby product.ProductId descending
                        join company in _db.Companies on product.CompanyId equals company.CompanyId
                        select new
                        {
                            product.ProductId,
                            product.Name,
                            product.Description,
                            product.AgeRestriction,
                            company.CompanyId,
                            company.Title,
                            product.Price
                        };

            return query;
        }

    }
}