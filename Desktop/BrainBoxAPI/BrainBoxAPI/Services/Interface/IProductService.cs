using BrainBoxAPI.Models;

namespace BrainBoxAPI.Services.Interface
{
    public interface IProductService
    {
       Task <Product> AddProductAsync(Product addproduct);
        Task<int> DeleteProductAsync(int id);
        Task<int> UpdateProductAsync(Product updateproductEntity);
        Task<IEnumerable<Product>> SearchProductAsync(string search);
        Task<Product> GetProductAsync(int contactId);
        Task<IEnumerable<Product>> GetAllProductAsync();

    }
}
