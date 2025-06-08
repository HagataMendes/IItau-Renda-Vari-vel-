using Itau.Investimentos.Core; // Para referenciar a classe Operacao
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itau.Investimentos.Infrastructure.Repositories.Interfaces
{
    public interface IOperacaoRepository
    {
        // Método para buscar operações de compra/venda por usuário e ativo
        Task<IEnumerable<Operacao>> GetOperacoesByUsuarioAndAtivoAsync(int usuarioId, int ativoId);

        // Método para adicionar uma nova operação (útil para testes ou futuras inserções)
        Task AddOperacaoAsync(Operacao operacao);
    }
}