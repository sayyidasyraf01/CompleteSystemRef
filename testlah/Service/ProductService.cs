using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using testlah.Data;
using testlah.Model;

namespace testlah.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            return await _db.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, string name, decimal price, int categoryId)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            product.Name = name;
            product.Price = price;
            product.CategoryId = categoryId;
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }
    }

    public interface IProductService
    {
        Task<IList<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(int id, string name, decimal price, int categoryId);
        Task<bool> DeleteProductAsync(int id);
    }
}
