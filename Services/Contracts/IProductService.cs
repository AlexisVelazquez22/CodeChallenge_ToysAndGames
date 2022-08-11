using DB.Models;
using Services.DTOs;
using Services.ViewModels;

namespace Services.Contracts
{
    public interface IProductService
    {
        public IQueryable<ProductCompanyDTO> Get();
        public Task<Product> Add(ProductRequest model);
        public Task<Product> Edit(ProductRequest model, int id);
        public Task<bool> Delete(int id);
    }
}
