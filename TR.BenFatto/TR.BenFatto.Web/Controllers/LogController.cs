using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TR.BenFatto.Application.Interfaces;
using TR.BenFatto.Application.ViewModels;

namespace TR.BenFatto.Web.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserLogService _service;

        public LogController(ILogger<HomeController> logger, IUserLogService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index(string ip, string hour, string userAgent)
        {
            TimeSpan? pHour = !string.IsNullOrEmpty(hour) ? TimeSpan.Parse(hour) : null;
            var result = _service.GetAll(ip, pHour, userAgent).Result;
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserLogViewModel userLog)
        {

            if (ModelState.IsValid)
            {
                _service.Add(userLog);
                return RedirectToAction(nameof(Index));
            }
            return View(userLog);
        }

        [HttpGet()]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = _service.GetById(id.Value);

            if (product == null) return NotFound();

            return View(product.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserLogViewModel userLog)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(userLog);
                }
                catch (Exception ex)
                {
                    ViewBag.Erro = ex.Message;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(userLog);
        }

        [HttpGet()]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var product = _service.GetById(id.Value);

            if (product == null) return NotFound();

            return View(product.Result);
        }

        [HttpGet()]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            try
            {
                _service.Remove(id.Value);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
