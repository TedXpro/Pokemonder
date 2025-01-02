using MongoDB.Driver;
using pokemonder.Models;

public class PokemonService : IPokemonService
{
    private readonly IMongoCollection<Pokemon> _pokemonCpollection;
    public PokemonService(IConfiguration configuration){
        var client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
        var database = client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
        _pokemonCpollection = database.GetCollection<Pokemon>(configuration["MongoDbSettings:CollectionName"]);
    }

    public async Task<List<Pokemon>> GetPokemons()
    {
        return await _pokemonCpollection.Find(_ => true).ToListAsync();
    }

    public async Task<Pokemon> GetPokemon(string id)
    {
        return await _pokemonCpollection.Find(pokemon => pokemon.ID == id).FirstOrDefaultAsync();
    }

    public async Task<Pokemon> AddPokemon(Pokemon newPokemon)
    {
        await _pokemonCpollection.InsertOneAsync(newPokemon);
        return newPokemon;
    }

    public async Task<Pokemon> UpdatePokemon(string id, Pokemon updatedPokemon)
    {
        await _pokemonCpollection.ReplaceOneAsync(pokemon => pokemon.ID == id, updatedPokemon);   
        return updatedPokemon;
    }

    public async Task<bool> DeletePokemon(string id)
    {
        var result = await _pokemonCpollection.DeleteOneAsync(pokemon => pokemon.ID == id);
        return result.DeletedCount > 0;
    }

    public async Task<Pokemon> GetPokemonByName(string name)
    {
        return await _pokemonCpollection.Find(pokemon => pokemon.Name == name).FirstOrDefaultAsync();
    }
}
