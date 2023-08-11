using DOTNET_Training.Data;

namespace DOTNET_Training.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly DataContext _dataContext;

        public CategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dataContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _dataContext.Categories.FindAsync(id);
        }

        public async Task<Category> GetOrCreateCategory(Category category)
        {
            var existingCategory = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);

            if (existingCategory != null)
            {
                return existingCategory;
            }
            else
            {
                _dataContext.Categories.Add(category);
                await _dataContext.SaveChangesAsync();
                return category;
            }
        }

        public async Task<List<Category>?> UpdateCategory(int id, Category updatedCategory)
        {
            var existingCategory = await _dataContext.Categories.FindAsync(id);

            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Name = updatedCategory.Name;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Categories.ToListAsync();
        }

        public async Task<List<Category>?> DeleteCategory(int id)
        {
            var existingCategory = await _dataContext.Categories.FindAsync(id);

            if (existingCategory == null)
            {
                return null;
            }

            _dataContext.Categories.Remove(existingCategory);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Categories.ToListAsync() ;
        }
    }
}
