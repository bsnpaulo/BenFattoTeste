using TR.BenFatto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.BenFatto.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(int id);
        void Add(Order model);
        void Update(Order model);
        void Remove(Order model);
    }
}
