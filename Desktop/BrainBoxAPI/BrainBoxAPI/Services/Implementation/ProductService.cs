using BrainBoxAPI.Data;
using BrainBoxAPI.Models;
using BrainBoxAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace BrainBoxAPI.Services.Implementation
{
    public class ProductService : IProductService
    {
       private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException();
        }
        public async Task<Product> AddProductAsync(Product newproduct)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Name == newproduct.Name);

            if (existingProduct != null)
            {
                throw new Exception("Product already exists in the database.");
            }

            await _dbContext.Products.AddAsync(newproduct);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return newproduct;
            }
            else
            {
                throw new Exception("Product Not Added Successfully");
            }

        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var productToDelete = await _dbContext.Products.FindAsync(id);
            if (productToDelete != null)
            {
                _dbContext.Products.Remove(productToDelete);

                var result = await _dbContext.SaveChangesAsync();
                return result;
            }
            else
            {
                return 0;
            }

        }

        public async Task<int> UpdateProductAsync(Product updateproduct)
        {
            _dbContext.Products.Update(updateproduct);
            var updatedContact = await _dbContext.SaveChangesAsync();
            return updatedContact;
        }

        public async Task<IEnumerable<Product>> SearchProductAsync(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return await GetAllProductAsync();
            }
            var searchedContact = await _dbContext.Products.Where(item =>
            item.Name.ToLower().Contains(search.ToLower().Trim()) ||
            item.Category.ToLower().Contains(search.ToLower().Trim())).ToListAsync();
            return searchedContact;
        }
        public async Task<Product> GetProductAsync(int productId)
        {

            return await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _dbContext.Products.ToListAsync();

        }





    }
}
