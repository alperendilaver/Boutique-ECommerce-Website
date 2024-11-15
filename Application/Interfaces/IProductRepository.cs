using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> FilterByCategory(int categoryId);
        public Task<List<Product>> FilterByPrice(decimal minPrice, decimal maxPrice);
        public Task<List<Product>> FilterByStock(int minStock, int maxStock);
        public Task<List<Product>> FilterByName(string name);

        public Task AddFavorites(string userId,int productId);
        public Task RemoveFavorites(string userId,int productId);
        public Task<List<Product>> GetUserFavorites(string userId);

        public Task<List<Product>> GetRandomProducts();
        public Task<int> GetProductCount();
        public Task LogProduct(int productId,bool IsDolap);
        public Task<List<ProductRouteLog>> GetLogProduct(int productId);
        public Task<int> GetLogsCount();
    }
}