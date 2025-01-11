using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Calculadora_API.Models; 

namespace Calculadora_API.Controllers
{
    [ApiController]
    [Route("api/calculadora")]
    public class CalculadoraController : ControllerBase
    {
        // Lista para o histórico de cálculos
        private static readonly List<Operacao> Historico = new();

        [HttpPost("Calcular")]
        public IActionResult Calcular([FromBody] RequisicaoOperacao requisicao)
        {
            try
            {
                if (requisicao == null)
                    return BadRequest(new { Erro = "Requisição não pode ser nula." });

                if (requisicao.ValorA == null || requisicao.ValorB == null)
                    return BadRequest(new { Erro = "Os valores A e B não podem ser nulos." });

                if (string.IsNullOrWhiteSpace(requisicao.Operacao))
                    return BadRequest(new { Erro = "A operação não pode ser nula ou vazia." });

                // Calcula o resultado com base na operação (CGPT)
                double resultado = requisicao.Operacao switch
                {
                    "+" => requisicao.ValorA.Value + requisicao.ValorB.Value,
                    "-" => requisicao.ValorA.Value - requisicao.ValorB.Value,
                    "*" => requisicao.ValorA.Value * requisicao.ValorB.Value,
                    "/" => requisicao.ValorB.Value != 0 ? requisicao.ValorA.Value / requisicao.ValorB.Value : throw new DivideByZeroException(),
                    _ => throw new InvalidOperationException("Operação inválida.")
                };

                var operacao = new Operacao
                {
                    Id = Guid.NewGuid(), // "Globally Unique Identifier", cria um id aleatório.
                    ValorA = requisicao.ValorA.Value,
                    ValorB = requisicao.ValorB.Value,
                    OperacaoRealizada = requisicao.Operacao,
                    Resultado = resultado,
                    DataHora = DateTime.Now
                };

                Historico.Add(operacao);

                return Ok(new
                {
                    Mensagem = $"Dados armazenados com sucesso, ID de Armazenamento: {operacao.Id}",
                    Operacao = operacao
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        [HttpGet("Historico")]
        public IActionResult ObterHistorico()
        {
            return Ok(Historico);
        }

        [HttpDelete("ExcluirPorId/{id}")]
        public IActionResult ExcluirOperacao(Guid id)
        {
            try
            {
                var operacao = Historico.Find(op => op.Id == id);

                if (operacao == null)
                    return NotFound(new { Erro = "Operação não encontrada." });

                Historico.Remove(operacao);

                return Ok(new { Mensagem = $"Operação com ID {id} removida com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }
    }
}
