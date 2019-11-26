using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Mappings
{
    //classe de mapeamento atraves do FluentNHibernate
    public class AvaliacaoAtendimentoMap : ClassMap<AvaliacaoAtendimento>
    {
        //construtor
        public AvaliacaoAtendimentoMap()
        {
            //chave primária
            Id(map => map.Id).GeneratedBy.Increment();

            //demais propriedades...
            Map(map => map.Comentarios).Length(500).Not.Nullable();
            Map(map => map.Avaliacao).Not.Nullable();
        }
    }
}
