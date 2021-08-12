using TR.BenFatto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.BenFatto.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        void Add(Product model);
        void Update(Product model);
        void Remove(Product model);
    }
}
