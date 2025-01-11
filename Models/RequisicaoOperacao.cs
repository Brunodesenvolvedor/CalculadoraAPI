namespace Calculadora_API.Models
{
    public class RequisicaoOperacao
    {
        public double? ValorA { get; set; } // Primeiro valor (permitindo nulo)
        public double? ValorB { get; set; } // Segundo valor (permitindo nulo)
        public string Operacao { get; set; } // Operação realizada
    }
}
