using MongoDB.Bson.Serialization.Attributes;

namespace controle_de_contas_api.Domain
{
    public sealed partial class Conta : Entidade
    {
        #region Contrutores
        
        public Conta(string descricao, decimal? valor, bool valorProvisorio, bool pago) : base()
        {
            AlterarDescricao(descricao);
            this.Valor = valor;
            this.ValorProvisorio = valorProvisorio;
            this.Pago = pago;
        }

        public Conta(string descricao)
            => AlterarDescricao(descricao);

        #endregion
        
        [BsonElement("Nome")]
        public string Descricao { get; private set; }
        public decimal? Valor { get; private set; }
        public bool ValorProvisorio  { get; private set; }
        public bool Pago { get; private set; }
    }
}