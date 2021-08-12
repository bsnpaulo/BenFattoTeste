using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.BenFatto.Domain.Entities;
using TR.BenFatto.Domain.Interfaces;
using TR.BenFatto.Infra.Data.Context;

namespace TR.BenFatto.Infra.Data.Repositories
{
    public class UserLogRepository : IUserLogRepository
    {
        private readonly ApplicationDbContext _context;

        public UserLogRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<UserLog>> GetAll()
        {
            return await _context.UserLogs
                .ToListAsync();
        }

        public async Task<UserLog> GetById(int id)
        {
            var result = _context.UserLogs
                                 .AsNoTracking()
                                 .FirstOrDefault(p => p.Id == id);
            return result;
        }

        public async Task<IEnumerable<UserLog>> GetByIp(string ip)
        {
            var result = _context.UserLogs
                                 .AsNoTracking()
                                 .Where(p => p.IpAdress == ip);
            return result;
        }

        public async Task<IEnumerable<UserLog>> GetByUserAgent(DateTime date)
        {
            var result = _context.UserLogs
                                 .AsNoTracking()
                                 .Where(p => p.DateFromLog == date);
            return result;
        }

        public async Task<IEnumerable<UserLog>> GetByHour(TimeSpan time)
        {
            var result = _context.UserLogs
                                 .AsNoTracking()
                                 .Where(p => p.LogHour == time);
            return result;
        }

        public void Add(UserLog model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Remove(UserLog model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public void Update(UserLog model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<UserLog>> GetByUserAgent(string userAgent)
        {
            var result = _context.UserLogs
                                 .AsNoTracking()
                                 .Where(p => p.UserAgent.Contains(userAgent));
            return result;
        }
    }
}
