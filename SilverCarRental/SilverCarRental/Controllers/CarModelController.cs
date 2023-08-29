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
        private readonly IRepository<CarModel> _repository;

        public CarModelController(IRepository<CarModel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarModels()
        {
            var carModels = await _repository.Get(includeProperties: "Manufacturer");
            return Ok(carModels);
        }
    }
}
