using DB.Models;
using DB.ViewModels;

namespace Services.Contracts
{
    public interface IProductService
    {
        public IEnumerable<dynamic> Get();
        public Task<Product> Add(ProductRequest model);
        public Task<Product> Edit(ProductRequest model, int id);
        public Task<bool> Delete(int id);
    }
}
