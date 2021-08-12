using System;
using TR.BenFatto.Application.Interfaces;
using TR.BenFatto.Application.ViewModels;
using Xunit;

namespace TR.BenFatto.Test
{
    public class UnitTest
    {
        private readonly IUserLogService _service;

        public UnitTest(IUserLogService service)
        {
            _service = service;
        }

        [Fact]
        public void Test()
        {
            //arrange
            var result = false;
            var userLog = new UserLogViewModel
            {
                IpAdress = "200.212.36.25",
                NormalizedDate = "01-01-2000 22:30:00",
                UserAgent = "GET http://api/get"
            };

            //act
            try
            {
                _service.Add(userLog);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            //assert
            Assert.True(result);
        }
    }
}
