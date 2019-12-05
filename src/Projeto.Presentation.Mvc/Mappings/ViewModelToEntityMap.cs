using AutoMapper;
using Projeto.Data.Entities;
using Projeto.Presentation.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Mvc.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        public ViewModelToEntityMap()
        {
            CreateMap<CadastroAvaliacaoViewModel, AvaliacaoAtendimento>();
        }
    }
}
