namespace controle_de_contas_api.Domain
{
    public sealed partial class Competencia
    {
        public void AlterarDescricao(string descricao)
            => this.Descricao = descricao;
        
        public void AdicionarConta(Conta conta)
            => this.Contas.Add(conta);

        public void ExcluirConta(Conta conta)
            => this.Contas.Remove(conta);
        
        public void AlterarConta(Conta contaAlterada)
        {
            var conta = this.Contas.Find(x => x.Id == contaAlterada.Id);
            
            if(conta != null && contaAlterada.EhValido())
            {
                conta.AlterarDescricao(contaAlterada.Descricao);
                conta.AlterarValor(contaAlterada.Valor);
            }
        }
    }
}