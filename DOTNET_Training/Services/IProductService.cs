namespace DOTNET_Training.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetSingleProduct(int id);
        Task<List<Product>> AddProduct(Product newProduct);
        Task<List<Product>?> UpdateProduct(int id, Product updatedProduct);
        Task<List<Product>?> DeleteProduct(int id);
    }
}
