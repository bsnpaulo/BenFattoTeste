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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {            
            var result = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);
            return result;
        }
        
        public void Add(Product model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }
        
        public void Update(Product model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
        
        public void Remove(Product model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

    }
}