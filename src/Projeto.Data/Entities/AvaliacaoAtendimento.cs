using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Entities
{
    public class AvaliacaoAtendimento
    {
        public virtual int Id{ get; set; }
        public virtual string Comentarios { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }
    }

    public enum Avaliacao
    {
        Excelente = 1,
        Bom = 2,
        Regular = 3,
        Insuficiente = 4
    }
}
