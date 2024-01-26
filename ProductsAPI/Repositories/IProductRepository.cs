using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductListAsync();
        public Task<Product> GetProductByIdAsync(int Id);
        public Task<List<Product>> GetProductByColourAsync(string Colour);
        public Task<Product> AddProductAsync(Product product);
        public Task<int> UpdateProductAsync(Product product);
        public Task<int> DeleteProductAsync(int Id);
    }
}
