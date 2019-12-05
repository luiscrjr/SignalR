using Projeto.Data.Contracts;
using Projeto.Data.DTOs;
using Projeto.Data.Entities;
using Projeto.Data.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Data.Repositories
{
    public class AvaliacaoAtendimentoRepository
        : BaseRepository<AvaliacaoAtendimento>, IAvaliacaoAtendimentoRepository
    {
        private readonly string connectionString;

        public AvaliacaoAtendimentoRepository(string connectionString)
            : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<AvaliacaoDTO> GroupByAvaliacao()
        {
            using (var session = HibernateUtil.SessionFactory(connectionString).OpenSession())
            {
                return session.Query<AvaliacaoAtendimento>()
                    .GroupBy(a => a.Avaliacao)
                    .Select(
                        result => new AvaliacaoDTO
                        {
                            Avaliacao = result.Key.ToString(),
                            Total = result.Count()
                        }
                    )
                    .ToList();
            }
        }
    }
}
