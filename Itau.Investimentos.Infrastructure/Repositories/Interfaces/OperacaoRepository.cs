using Itau.Investimentos.Core; // Para referenciar a classe Operacao
using Itau.Investimentos.Infrastructure.Context; // Para referenciar o DbContext
using Itau.Investimentos.Infrastructure.Repositories.Interfaces; // Para implementar a interface
using Microsoft.EntityFrameworkCore; // Para usar métodos do EF Core como .Where, .ToListAsync, .AddAsync, .SaveChangesAsync
using System.Collections.Generic;
using System.Linq; // Para usar métodos LINQ como .Where
using System.Threading.Tasks;

namespace Itau.Investimentos.Infrastructure.Repositories
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private readonly ItauInvestimentosDbContext _context;

        // Construtor que recebe o DbContext por injeção de dependência
        public OperacaoRepository(ItauInvestimentosDbContext context)
        {
            _context = context;
        }

        // Implementação do método para adicionar uma nova operação
        public async Task AddOperacaoAsync(Operacao operacao)
        {
            await _context.Operacoes.AddAsync(operacao); // Adiciona a operação ao DbContext
            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
        }

        // Implementação do método para buscar operações por usuário e ativo
        public async Task<IEnumerable<Operacao>> GetOperacoesByUsuarioAndAtivoAsync(int usuarioId, int ativoId)
        {
            // Busca as operações no banco de dados usando LINQ to Entities e EF Core
            return await _context.Operacoes
                                 .Where(o => o.OprUsuId == usuarioId && o.OprAtiId == ativoId)
                                 .ToListAsync(); // Executa a consulta e retorna uma lista
        }
    }
}