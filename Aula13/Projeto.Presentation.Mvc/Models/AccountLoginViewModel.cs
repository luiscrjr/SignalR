using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Mvc.Models
{
    public class AccountLoginViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o login.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string Senha { get; set; }
    }
}
