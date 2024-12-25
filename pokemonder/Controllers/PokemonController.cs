using Microsoft.AspNetCore.Mvc;
using pokemonder.Models;

namespace pokemonder.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PokemonController : ControllerBase
    {
        private List<Pokemon> PokemonList = new List<Pokemon>(){
            new Pokemon
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Bulbasaur",
                Ability = "Overgrow",
                Type = "Grass/Poison",
                Level = "5"
            },
            new Pokemon
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Charmander",
                Ability = "Blaze",
                Type = "Fire",
                Level = "5"
            },
            new Pokemon
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Squirtle",
                Ability = "Torrent",
                Type = "Water",
                Level = "5"
            },
            new Pokemon
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Pikachu",
                Ability = "Static",
                Type = "Electric",
                Level = "7"
            },
              new Pokemon
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Eevee",
                Ability = "Run Away",
                Type = "Normal",
                Level = "10"
            }
        };

        [HttpGet]
        public List<Pokemon> Get()
        {
            return PokemonList;
        }

        [HttpGet("{id}")]
        public Pokemon GetPokemon(string id)
        {
            return PokemonList.FirstOrDefault(pokemon => pokemon.ID == id);
        }

        [HttpPost]
        public Pokemon AddPokemon(Pokemon newPokemon)
        {
            newPokemon.ID = Guid.NewGuid().ToString(); // // Generates a new globally unique identifier.
            PokemonList.Add(newPokemon);
            return newPokemon;
        }

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
        public void DeletePokemon(string id)
        {
            var pokemon = PokemonList.FirstOrDefault(pokemon => pokemon.ID == id);
            if (pokemon != null)
            {
                PokemonList.Remove(pokemon);
            }
        }
    }
}