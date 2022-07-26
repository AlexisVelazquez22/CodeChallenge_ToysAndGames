﻿using DB.Context;
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

        //Actualiza el método para devolver la entidad recién creada en el controller
        // actualiza el método para que sea async
        public void Add(ProductRequest model)
        {
            var product = new Product();

            //podrias usar Automapper para hacer el mapeo de los campos y no hacerlo a manita uno por uno.
            product.Name = model.Name;
            product.Description = model.Description;
            product.AgeRestriction = model.AgeRestriction;
            product.Price = model.Price;
            product.Company_Id = model.Company_Id;
            _db.Products.Add(product);

            //Utiliza la version async
            _db.SaveChanges();

            //devuelve la entidad recién creada
        }

        //renombra el método eliminate a algo como delete,
        // tampoco estas validando que el producto exista, si no existe el producto debes devolver un 404 - Not found al consumidor de la api
        // actualiza el método para que sea async
        public void Eliminate(int id)
        {
            var product = _db.Products.Find(id);
            _db.Remove(product);
            //Utiliza la version async
            _db.SaveChanges();
        }

        // No estas validando que el producto exista, si no existe el producto debes devolver un 404 - Not found al consumidor de la api
        //Actualiza el método para que sea async
        public void Edit(ProductRequest model)
        {
            var product = _db.Products.Find(model.Id);

            product.Name = model.Name;
            product.Description = model.Description;
            product.AgeRestriction = model.AgeRestriction;
            product.Price = model.Price;

            _db.Update();
            //no es necseario marcar la entidad como modified, el Change tracking de EF identifica cuando una entidad ha sido modficada
            _db.Entry(product).State = EntityState.Modified;
            //Utiliza la version async
            _db.SaveChanges();

            //devuelve la entidad actualizada
        }

        //renombra el metodo a algo mas entendible, Get o retrieve serian adecuados.
        //no devuelvas un ToList prefiere mejor la version IEnumerable<T> del método.
        //actuzaliza el metodo para que sea async
        public List<Product> Show()
        {
            // como buena practica es preferible utilizar el método AsNoTracking para aumentar el performance del query ya que elimina los rows
            // del tracking de cambios y de respaldo haciendo el retorno de datos mas rápido
            // tambien si solo vas a regesar la lista, no es necesario almacenarlo en una variable local, haz el return directo, incluso podrias hacer un
            //expression bodied method como pulic IEnumerable<Product> Get => _db.Products;
            //utiliza la versión async del ToList o el AsEnumerable dependiendo de como modifiques el metodo
            var lst = _db.Products.ToList();
            return lst;
        }
    }
}