using pokemonder.Models;

public interface IPokemonService
{
    public Task<List<Pokemon>> GetPokemons();
    public Task<Pokemon> GetPokemon(string id);
    public Task<Pokemon> AddPokemon(Pokemon pokemon);
    public Task<Pokemon> UpdatePokemon(string id, Pokemon pokemon);
    public Task<bool> DeletePokemon(string id);
    public Task<Pokemon> GetPokemonByName(string name);
}