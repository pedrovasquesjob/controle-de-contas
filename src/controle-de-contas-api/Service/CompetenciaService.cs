using AutoMapper;
using controle_de_contas_api.Domain;
using controle_de_contas_api.DTOs;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace controle_de_contas_api.Service
{
    public class CompetenciaService
    {
        private readonly IMapper _mapper;
        public IMongoCollection<Competencia> _collection {get; set;}
        public CompetenciaService(IOptions<DatabaseSettings> databaseSettings, IMapper mapper)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<Competencia>(databaseSettings.Value.CollectionName);
           
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompetenciaDTO>> GetAllAsync()
        {
            var lista = await _collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<CompetenciaDTO>>(lista);
        }

        public async Task CreateAsync(CompetenciaDTO dto)
        {
            var competencia = _mapper.Map<Competencia>(dto);
            await _collection.InsertOneAsync(competencia);
        }

        public async Task<CompetenciaDTO> GetByCompetencia(string competencia)
        {
            var comp = await _collection.Find(x => x.Descricao.Equals(competencia)).FirstOrDefaultAsync();
            return _mapper.Map<CompetenciaDTO>(comp);
        }

        public async Task UpdateAsync(CompetenciaDTO dto)
        {
            var comp = _mapper.Map<Competencia>(dto);
            await _collection.ReplaceOneAsync(x=> x.Id == dto.Id, comp);
        }

        public async Task RemoveAsync(string id)
            => await _collection.DeleteOneAsync(x => x.Id == id);
    }
}