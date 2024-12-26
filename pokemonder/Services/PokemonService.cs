using pokemonder.Models;

public class PokemonService : IPokemonService
{
    private static int _nextId = 6;
    static private List<Pokemon> PokemonList = new List<Pokemon>(){
            new Pokemon
            {
                ID = "0001",
                Name = "Bulbasaur",
                Ability = "Overgrow",
                Type = "Grass/Poison",
                Level = "5"
            },
            new Pokemon
            {
                ID = "0002",
                Name = "Charmander",
                Ability = "Blaze",
                Type = "Fire",
                Level = "5"
            },
            new Pokemon
            {
                ID = "0003",
                Name = "Squirtle",
                Ability = "Torrent",
                Type = "Water",
                Level = "5"
            },
            new Pokemon
            {
                ID = "0004",
                Name = "Pikachu",
                Ability = "Static",
                Type = "Electric",
                Level = "7"
            },
              new Pokemon
            {
                ID = "0005",
                Name = "Eevee",
                Ability = "Run Away",
                Type = "Normal",
                Level = "10"
            }
        };

    public List<Pokemon> GetPokemons()
    {
        return PokemonList;
    }

    public Pokemon GetPokemon(string id)
    {
        return PokemonList.FirstOrDefault(pokemon => pokemon.ID == id);
    }

    public Pokemon AddPokemon(Pokemon newPokemon)
    {
        newPokemon.ID = _nextId.ToString("0000");
        PokemonList.Add(newPokemon);
        return newPokemon;
    }

    public Pokemon UpdatePokemon(string id, Pokemon updatedPokemon)
    {
        var pokemon = PokemonList.FirstOrDefault(pokemon => pokemon.ID == id);
        if (pokemon != null)
        {
            pokemon.Name = updatedPokemon.Name;
            pokemon.Ability = updatedPokemon.Ability;
            pokemon.Type = updatedPokemon.Type;
            pokemon.Level = updatedPokemon.Level;
        }
        return pokemon;
    }

    public bool DeletePokemon(string id)
    {
        var pokemon = PokemonList.FirstOrDefault(pokemon => pokemon.ID == id);
        if (pokemon != null)
        {
            PokemonList.Remove(pokemon);
            return true;
        }
        return false;
    }

    public Pokemon GetPokemonByName(string name)
    {
        return PokemonList.FirstOrDefault(pokemon => pokemon.Name == name);
    }
}
