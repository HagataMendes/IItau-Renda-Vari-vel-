using Itau.Investimentos.Application.Services; // Para implementar a interface
using Itau.Investimentos.Infrastructure.Repositories.Interfaces; // Para usar o repositório de Operações
using System.Threading.Tasks;
using Itau.Investimentos.Core; // Para referenciar a classe Operacao
using System.Collections.Generic; // Para usar IEnumerable
using System.Linq; // Para usar métodos LINQ como Sum, Average, etc.

namespace Itau.Investimentos.Application.Services
{
    public class InvestimentosService : IInvestimentosService
    {
        private readonly IOperacaoRepository _operacaoRepository;

        // Construtor que recebe o IOperacaoRepository por injeção de dependência
        public InvestimentosService(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }

        // AQUI SERÁ IMPLEMENTADA A LÓGICA DA TAREFA 4: CALCULAR PREÇO MÉDIO
        public async Task<decimal> CalcularPrecoMedioPonderadoAsync(int usuarioId, int ativoId)
        {
            // 1. Buscar todas as operações de compra do usuário para o ativo específico
            // (Por enquanto, vamos considerar TODAS as operações para o cálculo simplificado do preço médio ponderado.
            // Ajustaremos se a regra for mais complexa, como apenas operações de compra ou um período específico).
            IEnumerable<Operacao> operacoes = await _operacaoRepository.GetOperacoesByUsuarioAndAtivoAsync(usuarioId, ativoId);

            if (operacoes == null || !operacoes.Any())
            {
                return 0; // Se não houver operações, o preço médio é zero.
            }

            // 2. Filtrar apenas operações de COMPRA, se essa for a regra para preço médio
            // (Assumindo OprTipoOperacao == "C" para compra, ajuste conforme seu enum ou string)
            var operacoesDeCompra = operacoes.Where(o => o.OprTipoOperacao == "C").ToList();

            if (!operacoesDeCompra.Any())
            {
                return 0; // Se não houver operações de compra, preço médio é zero.
            }

            // 3. Calcular o valor total ponderado e a quantidade total
            decimal valorTotalPonderado = operacoesDeCompra.Sum(o => o.OprQuantidade * o.OprPrecoUnitario);
            decimal quantidadeTotal = operacoesDeCompra.Sum(o => o.OprQuantidade);

            if (quantidadeTotal == 0)
            {
                return 0; // Evitar divisão por zero
            }

            // 4. Calcular o preço médio ponderado
            decimal precoMedioPonderado = valorTotalPonderado / quantidadeTotal;

            return precoMedioPonderado;
        }

        // Implementações futuras para outros métodos da Tarefa 3 iriam aqui, se necessário.
        // Ex: CalcularTotalInvestidoPorAtivoAsync, CalcularPosicaoGlobalComPLAsync, etc.
    }
}