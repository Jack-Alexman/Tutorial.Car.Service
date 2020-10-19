using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tutorial.Car.BL.Services;
using Tutorial.Car.Common.DTOs;

namespace Tutorial.Car.API.Controllers
{
    public class CarController: ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<CarDTO[]> GetAll() {
            return await _carService.GetAllAsync();
        }

        [HttpPost]
        public async Task Create([FromBody] CarDTO carDTO) {
            await _carService.CreateAsync(carDTO);
        }

        [HttpDelete("{id}")]
        public async Task Remove([FromQuery] long id){
            await _carService.RemoveAsync(id);
        }
    }
}
