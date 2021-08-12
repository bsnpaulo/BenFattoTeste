using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TR.BenFatto.Application.Interfaces;
using TR.BenFatto.Application.ViewModels;

namespace TR.BenFatto.Web.Controllers
{
    public class CreatePostController : Controller
    {
        private readonly ICreatePostService _service;

        public CreatePostController(ICreatePostService service)
        {
            _service = service;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreatePost model)
        {
            if (model.Arquivo == null)
            {
                ViewBag.Erro = "Arquivo não informado.";
                return View();
            }

            var extensao = Path.GetExtension(model.Arquivo.FileName);
            if (extensao.ToUpper() != ".LOG")
            {
                ViewBag.Erro = "Tipo do arquivo inválido.";
                return View();
            }

            try
            {
                var rt =_service.ProcessFile(model);
                if (rt)
                {
                    ViewBag.Sucesso = "Arquivo processado";
                    return View();
                }
                else
                {
                    ViewBag.Erro = "Falha ao processar o arquivo.";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View();
            }
        }
    }
}
