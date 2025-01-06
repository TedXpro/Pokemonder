using pokemonder.Models;

namespace pokemonder.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetPokemons();
        Task<Pokemon> GetPokemon(string id);
        Task<bool> AddPokemon(Pokemon pokemon);
        Task<bool> UpdatePokemon(string id, Pokemon pokemon);
        Task<bool> DeletePokemon(string id);
        Task<Pokemon> GetPokemonByName(string name);
    }
}