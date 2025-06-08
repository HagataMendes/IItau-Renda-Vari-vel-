using System;

namespace Itau.Investimentos.Core
{
    public class Cotacao
    {
        public int CotId { get; set; }
        public int CotAtiId { get; set; } // Foreign Key para Ativo
        public decimal CotPrecoUnitario { get; set; }
        public DateTime CotDataHora { get; set; }

        // Propriedade de navegação
        public Ativo? Ativo { get; set; } // Representa a relação com a tabela Ati_Ativos
    }
}