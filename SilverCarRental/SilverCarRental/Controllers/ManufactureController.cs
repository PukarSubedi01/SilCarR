using Microsoft.AspNetCore.Mvc;
using SilverCarRental.Data;
using SilverCarRental.Entities;
using System;

namespace SilverCarRental.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class ManufactureController : ControllerBase
{
    private readonly IRepository<Manufacturer> _repository;

    public ManufactureController(IRepository<Manufacturer> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllManufacturer()
    {
        var manufacturers =await _repository.Get();
        return Ok(manufacturers);
    }

    [HttpPost]
    public  IActionResult CreateManufacturer(Manufacturer manufacturer)
    {
        if (manufacturer == null)
        {
            return BadRequest("Manufacturer data is invalid.");
        }

         _repository.Insert(manufacturer);
          return CreatedAtAction(nameof(GetAllManufacturer), new { id = manufacturer.Id }, manufacturer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateManufacturer(long id, Manufacturer manufacturer)
    {
        if (manufacturer == null || id != manufacturer.Id)
        {
            return BadRequest("Manufacturer data is invalid.");
        }

         _repository.Update(manufacturer);
         return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteManufacturer(int id)
        {
        var manufacturer = await  _repository.GetByID(manu => manu.Id == id);
        if (manufacturer == null)
        {
            return NotFound();
        }

        await _repository.Delete(manufacturer);
        return NoContent();
    }
}

}
