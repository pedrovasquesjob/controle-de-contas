namespace controle_de_contas_api.Domain
{
    public sealed partial class Competencia : Entidade
    {
        public Competencia(string descricao, List<Conta> contas)
        {
            AlterarDescricao(descricao);
            foreach (var conta in contas)
                AdicionarConta(conta);
        }

        public string Descricao { get; private set; }
        public List<Conta> Contas { get; private set; } = new();

    }
}