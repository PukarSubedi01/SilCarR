using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SilverCarRental.Core.Interface;
using SilverCarRental.Entities;
using SilverCarRental.TempDatabase;

namespace SilverCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        IRepository<Car> carRepository;
        public CarController()
        {
            this.carRepository = new CarRepository<Car>();
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            var cars = carRepository.GetAll();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetAllCars()
        {
            var cars = carRepository.GetAll();
            return Ok(cars);
        }
    }
}
