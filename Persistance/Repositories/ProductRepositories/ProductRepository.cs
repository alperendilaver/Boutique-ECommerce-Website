using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NazOzturkContext  _context;
        public ProductRepository(NazOzturkContext context)
        {
            _context = context;
        }

        public async Task AddFavorites(string userId, int productId)
        {
            var user = await _context.Users.Include(u => u.FavorutiesProduct).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new Exception("Ürün bulunamadı.");
            }

            if (user.FavorutiesProduct == null)
            {
                user.FavorutiesProduct = new List<Product>();
            }

            if (!user.FavorutiesProduct.Any(p => p.Id == productId))
            {
                user.FavorutiesProduct.Add(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Bu ürün zaten favorilerde.");
            }

        }

        public async Task<List<Product>> FilterByCategory(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Product>> FilterByName(string name)
        {
            return await _context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task<List<Product>> FilterByPrice(decimal minPrice, decimal maxPrice)
        {
            return await _context.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToListAsync();
        }

        public async Task<List<Product>> FilterByStock(int minStock, int maxStock)
        {
            return await _context.Products.Where(p => p.Stock >= minStock && p.Stock <= maxStock).ToListAsync();
        }

        public Task<List<ProductRouteLog>> GetLogProduct(int productId)
        {
            return  _context.ProductRouteLogs.Where(p => p.ProductId == productId).ToListAsync(); 
        }

        public Task<int> GetLogsCount()
        {
            return _context.ProductRouteLogs.CountAsync();
        }

        public async Task<int> GetProductCount()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<List<Product>> GetRandomProducts()
        {
            return await _context.Products.OrderBy(p => Guid.NewGuid()).Take(6).ToListAsync();
        }

        public async Task<List<Product>> GetUserFavorites(string userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.FavorutiesProduct)
                .ToListAsync();
        }

        public async Task LogProduct(int productId, bool IsDolap)
        {
            await _context.ProductRouteLogs.AddAsync(new ProductRouteLog{IsDolap = IsDolap, ProductId = productId,DateCreated = DateTime.Now});
            await _context.SaveChangesAsync();
        }


        public async Task RemoveFavorites(string userId, int productId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId).Include(u => u.FavorutiesProduct)
                .FirstOrDefaultAsync();

            if (user == null)
            {
        
                throw new Exception("Kullanıcı bulunamadı.");
            }

            // Favori ürünler listesinin null olup olmadığını kontrol et
            if (user.FavorutiesProduct == null)
            {
                throw new Exception("Favori ürünler bulunamadı.");
            }

            var product = user.FavorutiesProduct
                .Where(p => p.Id == productId)
                .FirstOrDefault();
            if (product == null)
            {
                throw new Exception("Bu ürün favorilerde bulunamadı.");
            }

            user.FavorutiesProduct.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}