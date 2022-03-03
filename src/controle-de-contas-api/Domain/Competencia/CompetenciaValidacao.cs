namespace controle_de_contas_api.Domain
{
    public sealed partial class Competencia
    {
        public override bool EhValido()
        {
            if(string.IsNullOrEmpty(this.Descricao))
                return false;

            return true;
        }
    }
}