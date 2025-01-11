using System;

namespace Calculadora_API.Models
{
    public class Operacao
    {
        public Guid Id { get; set; } 
        public double ValorA { get; set; } 
        public double ValorB { get; set; } 
        public string OperacaoRealizada { get; set; }
        public double Resultado { get; set; } 
        public DateTime DataHora { get; set; } 
    }
}
