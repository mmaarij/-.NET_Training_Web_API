using DOTNET_Training.Data;

namespace DOTNET_Training.Services
{
    public class ProductService : IProductService
    {

        private readonly DataContext _dataContext;
        private readonly ICategoryService _categoryService;
        public ProductService(DataContext context, ICategoryService categoryService)
        {
            _dataContext = context;
            _categoryService = categoryService;
        }


        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _dataContext.Products.Include(p => p.Category).ToListAsync();
            return products;
        }

        public async Task<Product?> GetSingleProduct(int id)
        {
            var result = await _dataContext.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == id);
            return result;
        }

        public async Task<List<Product>> AddProduct(Product newProduct)
        {
            // Check if the category already exists in the database
            newProduct.Category = await _categoryService.GetOrCreateCategory(newProduct.Category);

            _dataContext.Products.Add(newProduct);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<List<Product>?> UpdateProduct(int id, Product updatedProduct)
        {
            var result = await _dataContext.Products.FindAsync(id);

            if (result is null)
            {
                return null;
            }
            else
            {
                updatedProduct.Category = await _categoryService.GetOrCreateCategory(updatedProduct.Category);

                result.Name = updatedProduct.Name;
                result.Description = updatedProduct.Description;
                result.Price = updatedProduct.Price;
                result.StockQuantity = updatedProduct.StockQuantity;
                result.Category = updatedProduct.Category;

                await _dataContext.SaveChangesAsync();

                return await _dataContext.Products.Include(p => p.Category).ToListAsync();
            }
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var result = await _dataContext.Products.FindAsync(id);

            if (result is null)
            {
                return null;
            }
            else
            {
                _dataContext.Products.Remove(result);
                await _dataContext.SaveChangesAsync();
                return await _dataContext.Products.Include(p => p.Category).ToListAsync();
            }
        }
    }
}
