
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SilverCarRental.Core.Interface;
using SilverCarRental.Entities;
using System.Linq.Expressions;

namespace SilverCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository repository;

        public CarController(ICarRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableCars(
            [FromQuery] string? make = null,
            [FromQuery] string? model = null,
            [FromQuery] decimal? startingPrice = null,
            [FromQuery] decimal? endingPrice = null
            )
           
        {
            var filters = new List<Expression<Func<Car, bool>>>();

            if (!make.IsNullOrEmpty())
            {
                filters.Add(car => car.Model.Manufacturer.Make == make);
            }
            if(!model.IsNullOrEmpty())
            {
                filters.Add(car => car.Model.Model == model);
            }
            if (startingPrice.HasValue && 
                endingPrice.HasValue && 
                startingPrice.Value > 0 && 
                endingPrice.Value > startingPrice.Value)
            {
                filters.Add(car => car.Rate >= startingPrice.Value && car.Rate <= endingPrice.Value);
            }
            if (!model.IsNullOrEmpty())
            {
                filters.Add(car => car.Model.Model == model);
            }
            var cars = await repository.GetAvailbaleCars(filters: filters ,includeProperties: "Model.Manufacturer");
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
                Year = carRequestDTO.Year,
                Rate = carRequestDTO.Rate

            };
             repository.Insert(car);
            return Ok(car);
        }


       
    }
}
