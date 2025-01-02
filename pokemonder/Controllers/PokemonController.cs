using Microsoft.AspNetCore.Mvc;
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
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_pokemonService.GetPokemons());
        }

        [HttpGet("{id}")]
        public ActionResult GetPokemon(string id)
        {
            try
            {
                return Ok(_pokemonService.GetPokemon(id));
            }
            catch (Exception)
            {
                return NotFound("Pokemon Not Found");
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddPokemon(Pokemon newPokemon)
        {
            return Ok(await _pokemonService.AddPokemon(newPokemon));
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePokemon(string id, Pokemon updatedPokemon)
        {
            return Ok(_pokemonService.UpdatePokemon(id, updatedPokemon));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePokemon(string id)
        {
            return Ok(_pokemonService.DeletePokemon(id));
        }

        [HttpGet("search/{name}")]
        public ActionResult GetPokemonByName(string name)
        {
            return Ok(_pokemonService.GetPokemonByName(name));
        }
    }
}