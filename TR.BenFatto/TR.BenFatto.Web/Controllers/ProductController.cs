using TR.BenFatto.Application.Interfaces;
using TR.BenFatto.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TR.BenFatto.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        private async Task LoadCategories()
        {
            var categorias = _categoryService.GetAll();
            ViewBag.ListaCategoria = new SelectList(categorias.Result.ToList(), "Id", "Name");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAll();
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Points, CategoryId")] ProductViewModel product)
        {
            LoadCategories();

            if (ModelState.IsValid)
            {
                _service.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet()]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = _service.GetById(id.Value);

            if (product == null) return NotFound();

            LoadCategories();
            return View(product.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Name, Points, CategoryId")] ProductViewModel product)
        {
            LoadCategories();

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(product);
                }
                catch (Exception ex)
                {
                    ViewBag.Erro = ex.Message;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(product);
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
