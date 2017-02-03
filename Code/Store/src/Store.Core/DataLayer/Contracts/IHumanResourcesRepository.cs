using System;
using System.Linq;
using Store.Core.EntityLayer.HumanResources;

namespace Store.Core.DataLayer.Contracts
{
    public interface IHumanResourcesRepository : IRepository
    {
        IQueryable<Employee> GetEmployees(Int32 pageSize, Int32 pageNumber);

		Employee GetEmployee(Employee entity);

		void AddEmployee(Employee entity);

		void UpdateEmployee(Employee changes);

		void DeleteEmployee(Employee entity);
	}
}
