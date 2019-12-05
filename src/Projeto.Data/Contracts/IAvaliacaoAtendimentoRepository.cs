using Projeto.Data.DTOs;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Contracts
{
    public interface IAvaliacaoAtendimentoRepository
            :IBaseRepository<AvaliacaoAtendimento>
    {
        List<AvaliacaoDTO> GroupByAvaliacao();
    }
}
