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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var car = carRepository.GetById(id);
            return Ok(car);
        }

        [HttpGet]
        [Route("{color}")]
        public IActionResult GetByColor(string color)
        {   
            var cars = carRepository.GetByColor(color);
            return Ok(cars);
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] Car car)
        {
            carRepository.Insert(car);
            return Ok(car);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] Car car)
        {
            carRepository.Update(id, car);
            return Ok(car);
        }
    }
}
