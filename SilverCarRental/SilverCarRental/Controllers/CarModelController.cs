using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SilverCarRental.Data;
using SilverCarRental.DTOs;
using SilverCarRental.Entities;

namespace SilverCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : ControllerBase
    {
        private readonly IRepository<CarModel> repository;

        public CarModelController(IRepository<CarModel> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarModels()
        {
            var carModels = await repository.Get(includeProperties: "Manufacturer");
            return Ok(carModels);
        }

        [HttpPost]
        public IActionResult SaveCarModel([FromBody] CarModelRequestDTO carModelRequestDTO)
        {

            var carModel = new CarModel()
            {
                Id = carModelRequestDTO.Id,
                Model = carModelRequestDTO.Model,
                ManufacturerId = carModelRequestDTO.ManufacturerId,
            };
            repository.Insert(carModel);
            return Ok(carModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update
            (int id, CarModelResponseDTO updatedCarModel)
        {
            try
            {
                var existingCarModel = repository.GetByID(id);

                if (existingCarModel == null)
                {
                    return NotFound();
                }
                existingCarModel.Model = updatedCarModel.Model;

                repository.Update(existingCarModel);
                return Ok(existingCarModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                bool deletionSuccessful = repository.Delete(id);

                if (deletionSuccessful)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Deletion failed or item not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request.");
            }
        }
    }
}

