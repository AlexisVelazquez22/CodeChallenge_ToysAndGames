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

        public void AddCompany(CompanyRequest model)
        {
            var company = new Company();

            company.Company_Name = model.Name;
            _db.Companies.Add(company);
            _db.SaveChanges();
        }

        public List<Company> ShowCompanies()
        {
            var companies = _db.Companies.ToList();
            return companies;
        }
    }
}
