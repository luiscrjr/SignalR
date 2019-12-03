using AutoMapper;
using Projeto.Data.DTOs;
using Projeto.Presentation.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Mvc.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        public EntityToViewModelMap()
        {
            CreateMap<AvaliacaoDTO, PieChartViewModel>()
                .AfterMap((src, dest) =>
                {
                    dest.name = src.Avaliacao;
                })
                .AfterMap((src, dest) =>
                {
                    dest.data = new int[] { src.Total };
                });
        }
    }
}
