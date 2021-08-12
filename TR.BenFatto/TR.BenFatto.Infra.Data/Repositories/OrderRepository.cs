using TR.BenFatto.Domain.Entities;
using TR.BenFatto.Domain.Interfaces;
using TR.BenFatto.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders
                .ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {            
            var result = _context.Orders
                .FirstOrDefault(p => p.Id == id);
            return result;
        }
        
        public void Add(Order model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }
        
        public void Update(Order model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
        
        public void Remove(Order model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }
    }
}