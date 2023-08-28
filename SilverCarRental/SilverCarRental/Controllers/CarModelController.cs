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
        public async Task<IActionResult> SaveCarModel([FromBody] CarModelRequestDTO carModelRequestDTO)
        {

            var carModel = new CarModel()
            {
                Model = carModelRequestDTO.Model,
                ManufacturerId = carModelRequestDTO.ManufacturerId,
            };
            await repository.Insert(carModel);
            return Ok(carModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update
            (int id, CarModelResponseDTO updatedCarModel)
        {
            try
            {
                var existingCarModel = await repository.GetByID(car => car.Id == id);

                if (existingCarModel == null)
                {
                    return NotFound();
                }
                existingCarModel.Model = updatedCarModel.Model;

                var updatedCar = await repository.Update(existingCarModel);
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
         
                var deletedModel = await repository.Delete(id);
            return Ok(deletedModel);
            
         
        }
    }
}

