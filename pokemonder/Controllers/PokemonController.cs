using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using pokemonder.Models;

namespace pokemonder.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        private static int _nextId = 6;

        [HttpGet]
        public List<Pokemon> Get()
        {
            return _pokemonService.GetPokemons();
        }

        [HttpGet("{id}")]
        public ActionResult GetPokemon(string id)
        {
            try {
                return Ok(_pokemonService.GetPokemon(id));
            } catch (Exception e) {
                return NotFound("Pokemon Not Found");
            }
            
        }

        [HttpPost]
        public Pokemon AddPokemon(Pokemon newPokemon)
        {
            newPokemon = _pokemonService.AddPokemon(newPokemon);
            return newPokemon;
        }

        [HttpPut("{id}")]
        public Pokemon UpdatePokemon(string id, Pokemon updatedPokemon)
        {
            return _pokemonService.UpdatePokemon(id, updatedPokemon);
        }

        [HttpDelete("{id}")]
        public bool DeletePokemon(string id)
        {
            return _pokemonService.DeletePokemon(id);
        }

        [HttpGet("search/{name}")]
        public Pokemon GetPokemonByName(string name)
        {
            return _pokemonService.GetPokemonByName(name);
        }
    }
}