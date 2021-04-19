using System;
using DBankAPI.Enums;
using NetDevPack.Messaging;

namespace DBankAPI.DBankDomain.Commands
{
    public abstract class LancamentoCommand : Command
    {        
        public int Id { get; protected set; }

        public DateTime DataHora { get; protected set; }

        public int ContaCorrenteOrigemId { get; protected set; }
        public int ContaCorrenteId { get; protected set; }
        
        public OperacaoEnum Operacao { get; protected set; }

        public decimal Valor { get; protected set; }

        public string Observacao { get; protected set; }
    }
}
