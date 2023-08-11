namespace DOTNET_Training.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(int id);
        Task<Category> GetOrCreateCategory(Category category);
        Task<List<Category>?> UpdateCategory(int id, Category updatedCategory);
        Task<List<Category>?> DeleteCategory(int id);
    }
}
