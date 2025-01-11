using Microsoft.AspNetCore.Mvc;
using pokemonder.Models;
using pokemonder.Services;

namespace pokemonder.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService? _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPokemons()
        {
            try
            {
                var pokemons = await _pokemonService?.GetPokemons()!;
                if (pokemons == null)
                {
                    throw new Exception("There are No Pokemons saved in the database!");
                }
                return Ok(pokemons);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}")] // [HttpGet("id/{id}")] or "{id:int}" is also possible! its to avoid confilcts with the other Get request namely GetPokemonByName
        public async Task<ActionResult> GetPokemonById(string id)
        {
            try
            {
                var pokemon = await _pokemonService?.GetPokemon(id)!;
                if (pokemon != null)
                {
                    return Ok(pokemon);
                }
                throw new Exception($"There is no Pokemon with id => {id}");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddPokemon(Pokemon newPokemon)
        {
            try
            {
                if (await _pokemonService?.AddPokemon(newPokemon)! == true)
                {
                    return Ok("Pokemon Added Successfully");
                }
                throw new Exception("Failed to Add Pokemon!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePokemon(string id, Pokemon currPokemon)
        {
            try
            {
                if (await _pokemonService?.UpdatePokemon(id, currPokemon)! == true)
                {
                    return Ok("Pokemon Updated Successfully");
                }
                throw new Exception($"No Pokemon with id => {id} found to Update!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePokemon(string id)
        {
            try
            {
                if (await _pokemonService?.DeletePokemon(id)! == true)
                {
                    return Ok("Pokemon Deleted Successfully");
                }
                throw new Exception($"No Pokemon with id => {id} found to Delete!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("name/{name}")] // [HttpGet("{name}")] is also possible! its to avoid confilcts with the other Get request namely GetPokemonById   
        public async Task<ActionResult> GetPokemonByName(string name)
        {
            try
            {
                var pokemon = await _pokemonService?.GetPokemonByName(name)!;
                if (pokemon != null)
                {
                    return Ok(pokemon);
                }
                throw new Exception($"There is no Pokemon with name => {name}");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}