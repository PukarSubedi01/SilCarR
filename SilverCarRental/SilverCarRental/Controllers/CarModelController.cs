using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SilverCarRental.Data;
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
                ManufacturerId = carModelRequestDTO.ManufacturerId,
                Model = carModelRequestDTO.Model,
               

            };
            repository.Insert(carModel);
            return Ok(carModel);
        }

        [HttpPut]
        public IActionResult UpdateCarModel([FromBody] CarModelRequestDTO carModelRequestDTO)
        {
            var CarModel = new CarModel()
            {
                ManufacturerId = carModelRequestDTO.ManufacturerId,
                Model = carModelRequestDTO.Model,
            };
            repository.Update(CarModel);
            return Ok(CarModel);
        }
        [HttpDelete("Delete{id}")]
        public IActionResult DeleteCarModel(int id)
        {
            var DeleteCar = repository.GetByID(id);
            if (DeleteCar == null)
            {
                return NotFound();
            }
            repository.Delete(DeleteCar);
            return Ok(DeleteCar);
        }
       
    }
}
