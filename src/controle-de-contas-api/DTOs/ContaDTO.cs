namespace controle_de_contas_api.DTOs
{
    public record ContaDTO(string Id, string Descricao, decimal? Valor, bool ValorProvisorio, bool Pago) : EntidadeDTO(Id);
}