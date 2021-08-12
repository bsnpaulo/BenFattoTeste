using AutoMapper;
using TR.BenFatto.Application.Interfaces;
using TR.BenFatto.Application.ViewModels;
using TR.BenFatto.Domain.Entities;
using TR.BenFatto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Application.Services
{
    public class UserLogService : IUserLogService
    {
        private readonly IUserLogRepository _userLogRepository;
        private readonly IMapper _mapper;

        public UserLogService(IUserLogRepository userLogRepository, IMapper mapper)
        {
            _userLogRepository = userLogRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserLogViewModel>> GetAll(string ip, TimeSpan? hour, string userAgent)
        {
            IEnumerable<UserLog> userLogs;

            if (!string.IsNullOrEmpty(ip))
            {
                userLogs = await _userLogRepository.GetByIp(ip);
                return _mapper.Map<List<UserLogViewModel>>(userLogs);
            }

            if (hour != null)
            {
                userLogs = await _userLogRepository.GetByHour(hour.Value);
                return _mapper.Map<List<UserLogViewModel>>(userLogs);
            }

            if (!string.IsNullOrEmpty(userAgent))
            {
                userLogs = await _userLogRepository.GetByUserAgent(userAgent);
                return _mapper.Map<List<UserLogViewModel>>(userLogs);
            }

            userLogs = await _userLogRepository.GetAll();
            return _mapper.Map<List<UserLogViewModel>>(userLogs);
        }

        public async Task<UserLogViewModel> GetById(int id)
        {
            var userLog = await _userLogRepository.GetById(id);
            return _mapper.Map<UserLogViewModel>(userLog);
        }

        public async Task<IEnumerable<UserLogViewModel>> GetByIp(string ip)
        {
            var userLogs = await _userLogRepository.GetByIp(ip);
            return _mapper.Map<List<UserLogViewModel>>(userLogs);
        }

        public async Task<IEnumerable<UserLogViewModel>> GetByHour(TimeSpan time)
        {
            var userLogs = await _userLogRepository.GetByHour(time);
            return _mapper.Map<List<UserLogViewModel>>(userLogs);
        }

        public async Task<IEnumerable<UserLogViewModel>> GetByUserAgent(string userAgent)
        {
            var userLogs = await _userLogRepository.GetByUserAgent(userAgent);
            return _mapper.Map<List<UserLogViewModel>>(userLogs);
        }

        public void Add(UserLogViewModel model)
        {
            var mapUserLog = _mapper.Map<UserLog>(model);
            var date = DateTime.Parse(mapUserLog.NormalizedDate);
            mapUserLog.DateFromLog = date;
            mapUserLog.LogHour = new TimeSpan(date.Hour, date.Minute, date.Second);
            _userLogRepository.Add(mapUserLog);
        }

        public void Update(UserLogViewModel model)
        {
            var mapUserLog = _mapper.Map<UserLog>(model);
            var date = DateTime.Parse(mapUserLog.NormalizedDate);
            mapUserLog.DateFromLog = date;
            mapUserLog.LogHour = new TimeSpan(date.Hour, date.Minute, date.Second);
            _userLogRepository.Update(mapUserLog);
        }

        public void Remove(int id)
        {
            var product = _userLogRepository.GetById(id).Result;
            _userLogRepository.Remove(product);
        }
    }
}