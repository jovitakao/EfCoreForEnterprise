using System;
using System.Linq;
using System.Threading.Tasks;
using Store.Core.EntityLayer.Sales;

namespace Store.Core.DataLayer.Contracts
{
    public interface ISalesRepository : IRepository
    {
        IQueryable<Customer> GetCustomers(Int32 pageSize, Int32 pageNumber);

        Customer GetCustomer(Customer entity);

        void AddCustomer(Customer entity);

        void UpdateCustomer(Customer changes);

        void DeleteCustomer(Customer entity);

        IQueryable<Order> GetOrders(Int32 pageSize, Int32 pageNumber);

        Task<Order> GetOrderAsync(Order entity);

        Task<Int32> AddOrderAsync(Order entity);

        Task<Int32> UpdateOrderAsync(Order changes);

        void DeleteOrder(Order entity);

        OrderDetail GetOrderDetail(OrderDetail entity);

        Task<Int32> AddOrderDetailAsync(OrderDetail entity);

        void UpdateOrderDetail(OrderDetail changes);

        void DeleteOrderDetail(OrderDetail entity);

        IQueryable<Shipper> GetShippers(Int32 pageSize, Int32 pageNumber);

        Shipper GetShipper(Shipper entity);

        void AddShipper(Shipper entity);

        void UpdateShipper(Shipper changes);

        void DeleteShipper(Shipper entity);
    }
}
