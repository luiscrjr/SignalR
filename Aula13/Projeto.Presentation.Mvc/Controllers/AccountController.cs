using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Mvc.Models;

namespace Projeto.Presentation.Mvc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ("lribeiro".Equals(model.Login) && "admin".Equals(model.Senha))
                {
                    //criando a identificação do usuário...
                    var identity = new ClaimsIdentity(
                        new[] {
                            new Claim(ClaimTypes.Name, model.Login), //nome do usuário
                            new Claim(ClaimTypes.Role, "Administrador") //perfil de acesso
                        }, 
                        CookieAuthenticationDefaults.AuthenticationScheme
                        );

                    //autenticando o usuário...
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home"); //redirecionamento

                }
                else
                {
                    ViewBag.Mensagem = "Usuário inválido, tente novamente.";
                }
            }
            return View();
        }
    }
}