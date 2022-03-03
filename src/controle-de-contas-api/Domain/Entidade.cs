using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace controle_de_contas_api.Domain
{
    public abstract class Entidade
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; protected set; }

        public abstract bool EhValido();
    }
}