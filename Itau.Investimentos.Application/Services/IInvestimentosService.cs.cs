using Itau.Investimentos.Core; // Para referenciar as entidades como Operacao
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itau.Investimentos.Application.Services
{
    public interface IInvestimentosService
    {
        // Este é o método central para a Tarefa 4: Preço Médio
        Task<decimal> CalcularPrecoMedioPonderadoAsync(int usuarioId, int ativoId);

        // Podemos adicionar aqui os outros métodos para as outras lógicas de negócio da Tarefa 3, como:
        // Task<decimal> CalcularTotalInvestidoPorAtivoAsync(int usuarioId, int ativoId);
        // Task<decimal> CalcularPosicaoGlobalComPLAsync(int usuarioId);
        // Task<decimal> CalcularTotalCorretagemPorClienteAsync(int usuarioId);
    }
}