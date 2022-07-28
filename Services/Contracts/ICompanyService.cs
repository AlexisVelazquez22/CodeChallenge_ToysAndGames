using DB.Models;
using DB.ViewModels;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        public IEnumerable<Company> Get();

        public Task<Company> Add(CompanyRequest model);

    }

}
