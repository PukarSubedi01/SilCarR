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
        private readonly SilverDataContext context;

        public CarController(IRepository<Car> repository, SilverDataContext context)
        {
            this.repository = repository;
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCar()
        {
        
            var cars =  await context.Car.ToListAsync();
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
    }
}
