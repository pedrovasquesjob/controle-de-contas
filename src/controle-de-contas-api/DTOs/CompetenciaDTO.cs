namespace controle_de_contas_api.DTOs
{
    public record CompetenciaDTO (string Id, string Descricao, List<ContaDTO> Contas) : EntidadeDTO(Id)
    {
        public decimal? Total => Contas.Sum(x => x.Valor.HasValue ? x.Valor.Value : 0);
    }
}