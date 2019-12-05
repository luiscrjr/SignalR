using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
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

        public IActionResult IndexPooling()
        {
            return View();
        }

        public JsonResult CadastrarAvaliacao(CadastroAvaliacaoViewModel model,
            [FromServices] IMapper mapper, [FromServices] IAvaliacaoAtendimentoRepository repository)
        {
            if (!ModelState.IsValid)
            { 
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return Json("Ocorreram erros de validação");
            }

            try
            {
                var obj = mapper.Map<AvaliacaoAtendimento>(model);
                repository.SaveOrUpdate(obj);

                Response.StatusCode = StatusCodes.Status200OK;
                return Json("Avaliação cadastrada com sucesso.");
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Json("Erro: " + e.Message);
            }
        }

        public JsonResult ObterGraficoDeAvaliacoes(
            [FromServices] IMapper mapper, [FromServices] IAvaliacaoAtendimentoRepository repository)
        {
            try
            {
                var consulta = repository.GroupByAvaliacao();
                return Json(mapper.Map<List<PieChartViewModel>>(consulta));
            }
            catch (Exception e)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Json("Erro: " + e.Message);
            }
        }
    }
}