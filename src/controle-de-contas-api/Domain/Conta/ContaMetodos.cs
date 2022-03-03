namespace controle_de_contas_api.Domain
{
    public sealed partial class Conta
    {
        public void AlterarDescricao(string descricao)
            => this.Descricao = descricao;

        public void AlterarValor(decimal? valor)
            => this.Valor = valor;
    }
}