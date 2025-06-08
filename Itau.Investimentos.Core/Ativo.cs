namespace Itau.Investimentos.Core
{
    public class Ativo
    {
        public int AtiId { get; set; }
        public string AtiCodigo { get; set; } = string.Empty; // Ex: "ITUB3", "PETR4", "BOVA11"
        public string AtiNome { get; set; } = string.Empty;
    }
}