using DB.Context;
using DB.Models;
using DB.ViewModels;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _db;

        public CompanyService(AppDbContext db)
        {
            _db = db;
        }

        //No es necesario agregar el company, se entiende que por companyServices es un servicio que realiza operaciones con companies
        //convierte el metodo a Async
        public void AddCompany(CompanyRequest model)
        {
            var company = new Company();

            company.Company_Name = model.Name;
            _db.Companies.Add(company);
            //Usa la version async
            _db.SaveChanges();
        }

        //No es necesario agregar el Companies, se sobreentiende que por ser un CompanyService son operaciones relacioandas con companies
        // cambia el nombre del metodo a algo mas descriptivo como Get O retrieve show es para mostrar, no para obtener datos.
        // Devuelve IEnumerable en lugar de List.
        public List<Company> ShowCompanies()
        {
            var companies = _db.Companies.ToList();
            return companies;
        }
    }
}
