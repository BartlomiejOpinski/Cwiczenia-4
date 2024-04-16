using Cwiczenia_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia_4.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal { category = "Dog", hairColor = "Brown", id = 1, mass = 50.0, name = "Dong" },
        new Animal { category = "Cat", hairColor = "White", id = 2, mass = 10.0, name = "Kat" },
        new Animal { category = "Bird", hairColor = "Pink", id = 3, mass = 5.0, name = "BirdIsAWord" }
    };
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetStudent(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(a => a.id == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToEdit = _animals.FirstOrDefault(a => a.id == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToEdit);
        return NoContent();
    }
    
    
}