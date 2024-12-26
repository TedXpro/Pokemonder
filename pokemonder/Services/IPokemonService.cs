using pokemonder.Models;

public interface IPokemonService
{
    public List<Pokemon> GetPokemons();
    public Pokemon GetPokemon(string id);
    public Pokemon AddPokemon(Pokemon pokemon);
    public Pokemon UpdatePokemon(string id, Pokemon pokemon);
    public bool DeletePokemon(string id);
    public Pokemon GetPokemonByName(string name);
}