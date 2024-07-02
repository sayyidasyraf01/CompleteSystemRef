using Microsoft.EntityFrameworkCore;
using testlah.Data;
using testlah.Model;
using testlah.Service.testlah.Service;

namespace testlah.Service
{
    public class CategoryService : ICategoryService
    {

        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(int id, string name)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            category.CategoryName = name;
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return true;
        }
    }
    namespace testlah.Service
    {
        public interface ICategoryService
        {
            Task<IList<Category>> GetCategoriesAsync();
            Task<Category> GetCategoryByIdAsync(int id);
            Task<Category> CreateCategoryAsync(Category category);
            Task<Category> UpdateCategoryAsync(int id, string name);
            Task<bool> DeleteCategoryAsync(int id);
        }
    }
}

