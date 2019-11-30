using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Projeto.Data.Util;
using System;
using System.Collections.Generic;
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
    }
}
