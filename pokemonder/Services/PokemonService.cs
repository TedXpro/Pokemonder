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

    public List<Pokemon> GetPokemons()
    {
        return _pokemonCpollection.Find(_ => true).ToList();
    }

    public Pokemon GetPokemon(string id)
    {
        return _pokemonCpollection.Find(pokemon => pokemon.ID == id).FirstOrDefault();
    }

    public Pokemon AddPokemon(Pokemon newPokemon)
    {
        _pokemonCpollection.InsertOne(newPokemon);
        return newPokemon;
    }

    public Pokemon UpdatePokemon(string id, Pokemon updatedPokemon)
    {
        _pokemonCpollection.ReplaceOne(pokemon => pokemon.ID == id, updatedPokemon);   
        return updatedPokemon;
    }

    public bool DeletePokemon(string id)
    {
        return _pokemonCpollection.DeleteOne(pokemon => pokemon.ID == id).DeletedCount > 0;
    }

    public Pokemon GetPokemonByName(string name)
    {
        return _pokemonCpollection.Find(pokemon => pokemon.Name == name).FirstOrDefault();
    }
}
