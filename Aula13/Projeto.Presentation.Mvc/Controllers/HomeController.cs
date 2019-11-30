using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Mvc.Models;

namespace Projeto.Presentation.Mvc.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastroAvaliacao()
        {
            return View();
        }

        public JsonResult CadastrarAvaliacao(CadastroAvaliacaoViewModel model)
        {
            return Json("Sucesso!");
        }
    }
}