using TR.BenFatto.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Application.Interfaces
{
    public interface IUserLogService
    {
        Task<IEnumerable<UserLogViewModel>> GetAll(string ip, TimeSpan? hour, string userAgent);
        Task<UserLogViewModel> GetById(int id);
        Task<IEnumerable<UserLogViewModel>> GetByIp(string ip);
        Task<IEnumerable<UserLogViewModel>> GetByHour(TimeSpan time);
        Task<IEnumerable<UserLogViewModel>> GetByUserAgent(string userAgent);
        void Add(UserLogViewModel model);
        void Update(UserLogViewModel model);
        void Remove(int id);
    }
}
