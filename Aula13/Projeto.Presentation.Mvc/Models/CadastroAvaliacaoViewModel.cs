﻿using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Mvc.Models
{
    public class CadastroAvaliacaoViewModel
    {
        public Avaliacao Avaliacao { get; set; }
        public string Comentarios { get; set; }
    }
}