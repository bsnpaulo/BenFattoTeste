using TR.BenFatto.Domain.Entities;
using TR.BenFatto.Domain.Interfaces;
using TR.BenFatto.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace TR.BenFatto.Infra.Data.Repositories
{
    public class CreatePostRepository : ICreatePostRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserLogRepository _logRepository;

        public CreatePostRepository(ApplicationDbContext context, IUserLogRepository repository)
        {
            _context = context;
            _logRepository = repository;
        }

        public bool ProcessFile(IFormFile file)
        {
            try
            {
                var reg = new List<UserLog>();
                using (StreamReader sr = new StreamReader(file.OpenReadStream()))
                {
                    var registrosArquivo = new List<UserLog>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] arrDados = line.Split(' ');
                        string entireLine = line;
                        var numeroProntuario = arrDados[0];

                        var pData = Transformar(arrDados[3]);
                        var data = DateTime.Parse(pData[0]);
                        var time = new TimeSpan(int.Parse(pData[1]), int.Parse(pData[2]), int.Parse(pData[3]));
                        var useragent = line.Split(']')[1].ToString();

                        var registro = new UserLog()
                        {
                            NormalizedLog = entireLine,
                            IpAdress = arrDados[0],
                            NormalizedDate = arrDados[3],
                            DateFromLog = data,
                            LogHour = time,
                            UserAgent = useragent
                    };
                        reg.Add(registro);
                    }
                }

                foreach (var item in reg)
                {
                    _logRepository.Add(item);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static string[] Transformar(string a)
        {
            var res = a.Substring(1, a.Length - 1);
            return res.Split(':');
        }

    }
}