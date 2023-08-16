using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilverCarRental.Data;
using SilverCarRental.Entities;

namespace SilverCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IRepository<Car> repository;

        public CarController(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCar(
            [FromQuery] string? filterByMake = null,
            [FromQuery] string? filterByModel = null
            )
        {
            IEnumerable<Car> cars;
             if (filterByMake != null && filterByModel != null)
                {

                    cars = await repository.Get(includeProperties: "Model.Manufacturer", filter: car => car.Model.Manufacturer.Make == filterByMake && car.Model.Model == filterByModel);
                } 
            else if(filterByModel != null)
            {
                cars = await repository.Get(includeProperties: "Model.Manufacturer", filter: car => car.Model.Model == filterByModel);
            }
            else if (filterByMake != null) {
                cars = await repository.Get(includeProperties: "Model.Manufacturer", filter: car => car.Model.Manufacturer.Make == filterByMake);
            }
            else 
             cars = await repository.Get(includeProperties: "Model.Manufacturer");
            return Ok(cars);
        }

        [HttpPost]
        public  IActionResult SaveCar([FromBody] CarRequestDTO carRequestDTO)
        {
            var car = new Car()
            {
                Color = carRequestDTO.Color,
                Mileage = carRequestDTO.Mileage,
                ModelId = carRequestDTO.ModelId,
                Year = carRequestDTO.Year

            };
             repository.Insert(car);
            return Ok(car);
        }
        [HttpPut("UpdateCar/{id}")]
        public IActionResult UpdateCar(int id, [FromBody] CarRequestDTO carRequestDTO)
        {
            var car = repository.GetByID(id);

            if (car == null)
            {
                return NotFound();
            }

           
            car.Color = carRequestDTO.Color;
            car.Mileage = carRequestDTO.Mileage;
            car.ModelId = carRequestDTO.ModelId;
            car.Year = carRequestDTO.Year;

            repository.Update(car);

            return Ok(car);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCar(int id)
        {
            var entityToDelete = repository.GetByID(id);
            if (entityToDelete == null)
            {
                return NotFound();
            }

           repository.Delete(entityToDelete);
           return Ok(entityToDelete);


        }

    }
}
