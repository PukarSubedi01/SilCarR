using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SilverCarRental.Data;
using SilverCarRental.DTOs;
using SilverCarRental.Entities;

namespace SilverCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        private readonly IRepository<RentalCar> repository;

        public CarRentalController(IRepository<RentalCar> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRentalCars()
        {
            return Ok(await repository.Get(includeProperties: "User,Car.Model.Manufacturer"));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRentalCarById(int id)
        {
            //return Ok(await repository.GetByID(id, includeProperties: "User,Car.Model.Manufacturer"));
            return Ok(await repository.GetByID(x => x.Id == id, includeProperties: "User,Car.Model.Manufacturer"));
        }

        [HttpPost]
        public async Task<IActionResult> SaveRentalCar([FromBody] RentalCarDTO rentalCarDTO)
        {
            var rentalCar = new RentalCar()
            {
                CarId = rentalCarDTO.CarId,
                Insurance = rentalCarDTO.Insurance,
                IsAvailable = rentalCarDTO.IsAvailable,
                Location = rentalCarDTO.Location,
                ReturnDate = rentalCarDTO.ReturnDate,
                UserId = rentalCarDTO.UserId,
                Rate = rentalCarDTO.Rate,
            };

            await repository.Insert(rentalCar);
            return CreatedAtAction(nameof(GetRentalCarById), new {id = rentalCar.Id }, rentalCarDTO);
        }
    }
}
