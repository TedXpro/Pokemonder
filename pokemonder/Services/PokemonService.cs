using DnsClient.Protocol;
using MongoDB.Driver;
using pokemonder.Models;

namespace pokemonder.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IMongoCollection<Pokemon>? _pokemonCollection;
        public PokemonService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            _pokemonCollection = database.GetCollection<Pokemon>(configuration["MongoDbSettings:CollectionName"]);
        }

        public async Task<List<Pokemon>> GetPokemons()
        {
            try
            {
                var pokemons = await _pokemonCollection.Find(_ => true).ToListAsync();
                if (pokemons != null)
                {
                    return pokemons;
                }
                throw new Exception();
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public async Task<Pokemon> GetPokemon(string id)
        {
            try
            {
                var pokemon = await _pokemonCollection.Find(Pokemon => Pokemon.ID == id).FirstOrDefaultAsync();
                if (pokemon != null)
                {
                    return pokemon;
                }
                throw new Exception();
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public async Task<bool> AddPokemon(Pokemon newPokemon)
        {
            try
            {
                newPokemon.ID = null;
                await _pokemonCollection?.InsertOneAsync(newPokemon)!;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdatePokemon(string id, Pokemon updatedPokemon)
        {
            try
            {
                updatedPokemon.ID = id;
                var status = await _pokemonCollection.ReplaceOneAsync(pokemon => pokemon.ID == id, updatedPokemon);
                if (status.ModifiedCount == 0)
                {
                    throw new Exception();
                }
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletePokemon(string id)
        {
            try
            {
                var status = await _pokemonCollection?.DeleteOneAsync(Pokemon => Pokemon.ID == id)!;
                if (status.DeletedCount == 0)
                {
                    throw new Exception();
                }
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Pokemon> GetPokemonByName(string name)
        {
            try
            {
                var pokemon = await _pokemonCollection.Find(pokemon => pokemon.Name == name).FirstOrDefaultAsync();
                if (pokemon != null)
                {
                    return pokemon;
                }
                throw new Exception();
            }
            catch (Exception)
            {
                return null!;
            }
        }
    }
}