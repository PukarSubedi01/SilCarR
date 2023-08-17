using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SilverCarRental.Core.Interface;

namespace SilverCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {

        ICarRepository carRepository;
        public RentalController(ICarRepository repository)
        {
            carRepository = repository;
        }


        [HttpGet]
        public ActionResult Get(DateTime pickUpDate, DateTime dropOffDate)
        {
            var allTheCarsAvailable = this.carRepository.GetAllAvailableCars(pickUpDate, dropOffDate);
            return Ok(allTheCarsAvailable);
        }
    }
}