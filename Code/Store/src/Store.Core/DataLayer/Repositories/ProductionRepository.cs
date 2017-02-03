using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Core.DataLayer.Contracts;
using Store.Core.EntityLayer.Production;

namespace Store.Core.DataLayer.Repositories
{
    public class ProductionRepository : Repository, IProductionRepository
    {
        public ProductionRepository(IUserInfo userInfo, StoreDbContext dbContext)
            : base(userInfo, dbContext)
        {
        }

        public IQueryable<Product> GetProducts(Int32 pageSize, Int32 pageNumber)
        {
            return Paging<Product>(pageSize, pageNumber);
        }

        public Task<Product> GetProductAsync(Product entity)
        {
            return DbContext
                .Set<Product>()
                .FirstOrDefaultAsync(item => item.ProductID == entity.ProductID);
        }

        public Product GetProductByName(String productName)
        {
            return DbContext
                .Set<Product>()
                .FirstOrDefault(item => item.ProductName == productName);
        }

        public void AddProduct(Product entity)
        {
            DbContext.Set<Product>().Add(entity);

            CommitChanges();
        }

        public async Task<Int32> UpdateProductAsync(Product changes)
        {
            var entity = await GetProductAsync(changes);

            if (entity != null)
            {
                entity.ProductName = changes.ProductName;
                entity.ProductCategoryID = changes.ProductCategoryID;
                entity.UnitPrice = changes.UnitPrice;
                entity.Discontinued = changes.Discontinued;
                entity.Description = changes.Description;
            }

            return await CommitChangesAsync();
        }

        public void DeleteProduct(Product entity)
        {
            DbContext.Set<Product>().Remove(entity);

            CommitChanges();
        }

        public IQueryable<ProductCategory> GetProductCategories()
        {
            return DbContext.Set<ProductCategory>();
        }

        public ProductCategory GetProductCategory(ProductCategory entity)
        {
            return DbContext
                .Set<ProductCategory>()
                .FirstOrDefault(item => item.ProductCategoryID == entity.ProductCategoryID);
        }

        public void AddProductCategory(ProductCategory entity)
        {
            DbContext.Set<ProductCategory>().Add(entity);

            CommitChanges();
        }

        public void UpdateProductCategory(ProductCategory changes)
        {
            var entity = GetProductCategory(changes);

            if (entity != null)
            {
                entity.ProductCategoryName = changes.ProductCategoryName;

                CommitChanges();
            }
        }

        public void DeleteProductCategory(ProductCategory entity)
        {
            DbContext.Set<ProductCategory>().Remove(entity);

            CommitChanges();
        }

        public IQueryable<ProductInventory> GetProductInventories()
        {
            return DbContext.Set<ProductInventory>();
        }

        public ProductInventory GetProductInventory(ProductInventory entity)
        {
            return DbContext
                .Set<ProductInventory>()
                .FirstOrDefault(item => item.ProductInventoryID == entity.ProductInventoryID);
        }

        public Task<Int32> AddProductInventoryAsync(ProductInventory entity)
        {
            DbContext.Set<ProductInventory>().Add(entity);

            return CommitChangesAsync();
        }

        public void UpdateProductInventory(ProductInventory changes)
        {
            var entity = GetProductInventory(changes);

            if (entity != null)
            {
                entity.ProductID = changes.ProductID;
                entity.EntryDate = changes.EntryDate;
                entity.Quantity = changes.Quantity;

                CommitChanges();
            }
        }

        public void DeleteProductInventory(ProductInventory entity)
        {
            DbContext.Set<ProductInventory>().Remove(entity);

            CommitChanges();
        }
    }
}
