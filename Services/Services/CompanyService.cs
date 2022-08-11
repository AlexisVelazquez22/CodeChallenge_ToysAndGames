using DB.Context;
using DB.Models;
using Services.Contracts;
using Services.ViewModels;

namespace Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _db;

        public CompanyService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Company> Add(CompanyRequest model)
        {
            var company = new Company();
            company.Title = model.Title;
            _db.Companies.Add(company);
            await _db.SaveChangesAsync();

            return company;
        }

        public IEnumerable<Company> Get() => _db.Companies.ToList();

    }
}
