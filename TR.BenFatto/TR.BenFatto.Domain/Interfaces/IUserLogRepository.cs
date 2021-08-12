using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TR.BenFatto.Domain.Entities;

namespace TR.BenFatto.Domain.Interfaces
{
    public interface IUserLogRepository
    {
        Task<IEnumerable<UserLog>> GetAll();
        Task<UserLog> GetById(int id);
        Task<IEnumerable<UserLog>> GetByIp(string ip);
        Task<IEnumerable<UserLog>> GetByHour(TimeSpan time);
        Task<IEnumerable<UserLog>> GetByUserAgent(string userAgent);
        void Add(UserLog model);
        void Update(UserLog model);
        void Remove(UserLog model);
    }
}
