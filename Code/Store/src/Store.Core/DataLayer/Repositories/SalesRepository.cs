using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Core.DataLayer.Contracts;
using Store.Core.EntityLayer.Sales;

namespace Store.Core.DataLayer.Repositories
{
    public class SalesRepository : Repository, ISalesRepository
    {
        public SalesRepository(IUserInfo userInfo, StoreDbContext dbContext)
            : base(userInfo, dbContext)
        {
        }

        public IQueryable<Customer> GetCustomers(Int32 pageSize, Int32 pageNumber)
        {
            return Paging<Customer>(pageSize, pageNumber);
        }

        public Customer GetCustomer(Customer entity)
        {
            return DbContext
                .Set<Customer>()
                .FirstOrDefault(item => item.CustomerID == entity.CustomerID);
        }

        public void AddCustomer(Customer entity)
        {
            DbContext.Set<Customer>().Add(entity);

            CommitChanges();
        }

        public void UpdateCustomer(Customer changes)
        {
            var entity = GetCustomer(changes);

            if (entity != null)
            {
                entity.CompanyName = changes.CompanyName;
                entity.ContactName = changes.ContactName;

                CommitChanges();
            }
        }

        public void DeleteCustomer(Customer entity)
        {
            DbContext.Set<Customer>().Remove(entity);

            CommitChanges();
        }

        public IQueryable<Order> GetOrders(Int32 pageSize, Int32 pageNumber)
        {
            return Paging<Order>(pageSize, pageNumber);
        }

        public async Task<Order> GetOrderAsync(Order entity)
        {
            return await DbContext
                .Set<Order>()
                .Include(p => p.OrderDetails)
                .FirstOrDefaultAsync(item => item.OrderID == entity.OrderID);
        }

        public Task<Int32> AddOrderAsync(Order entity)
        {
            DbContext.Set<Order>().Add(entity);

            Add(entity);

            return CommitChangesAsync();
        }

        public async Task<Int32> UpdateOrderAsync(Order changes)
        {
            var entity = await GetOrderAsync(changes);

            if (entity != null)
            {
                entity.OrderDate = changes.OrderDate;
                entity.CustomerID = changes.CustomerID;
                entity.EmployeeID = changes.EmployeeID;
                entity.ShipperID = changes.ShipperID;
                entity.Total = changes.Total;
                entity.Comments = changes.Comments;

                Update(entity);
            }

            return await CommitChangesAsync();
        }

        public void DeleteOrder(Order entity)
        {
            DbContext.Set<Order>().Remove(entity);

            CommitChanges();
        }

        public OrderDetail GetOrderDetail(OrderDetail entity)
        {
            return DbContext
                .Set<OrderDetail>()
                .FirstOrDefault(item => item.OrderID == entity.OrderID && item.ProductID == entity.ProductID);
        }

        public Task<Int32> AddOrderDetailAsync(OrderDetail entity)
        {
            DbContext.Set<OrderDetail>().Add(entity);

            return CommitChangesAsync();
        }

        public void UpdateOrderDetail(OrderDetail changes)
        {
            var entity = GetOrderDetail(changes);

            if (entity != null)
            {
                entity.ProductID = changes.ProductID;
                entity.ProductName = changes.ProductName;
                entity.UnitPrice = changes.UnitPrice;
                entity.Quantity = changes.Quantity;
                entity.Total = changes.Total;

                CommitChanges();
            }
        }

        public void DeleteOrderDetail(OrderDetail entity)
        {
            DbContext.Set<OrderDetail>().Remove(entity);

            CommitChanges();
        }

        public IQueryable<Shipper> GetShippers(Int32 pageSize, Int32 pageNumber)
        {
            return Paging<Shipper>(pageSize, pageNumber);
        }

        public Shipper GetShipper(Shipper entity)
        {
            return DbContext
                .Set<Shipper>()
                .FirstOrDefault(item => item.ShipperID == entity.ShipperID);
        }

        public void AddShipper(Shipper entity)
        {
            DbContext.Set<Shipper>().Add(entity);

            CommitChanges();
        }

        public void UpdateShipper(Shipper changes)
        {
            var entity = GetShipper(changes);

            if (entity != null)
            {
                entity.CompanyName = changes.CompanyName;
                entity.ContactName = changes.ContactName;

                CommitChanges();
            }
        }

        public void DeleteShipper(Shipper entity)
        {
            DbContext.Set<Shipper>().Remove(entity);

            CommitChanges();
        }
    }
}
