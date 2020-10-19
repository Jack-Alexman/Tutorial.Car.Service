using System.Net.Http;
using System.Threading.Tasks;
using Tutorial.Car.BL.Validators;
using Tutorial.Car.Common.DTOs;
using Tutorial.Car.Common.IRepositories;

namespace Tutorial.Car.BL.Services
{
    public interface ICarService
    {
        Task<CarDTO[]> GetAllAsync();
        Task CreateAsync(CarDTO carDTO);
        Task RemoveAsync(long carId);
    }

    public class CarService: ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarValidator _carValidator;

        public CarService(ICarRepository carRepository,
                          ICarValidator carValidator)
        {
            _carRepository = carRepository;
            _carValidator = carValidator;
        }

        public async Task<CarDTO[]> GetAllAsync() {            
            return await _carRepository.GetAllAsync();
        }

        public async Task CreateAsync(CarDTO carDTO) {
            await _carValidator.CanCreateAsync(carDTO);
            await _carRepository.CreateAsync(carDTO);
        }
        public async Task RemoveAsync(long carId)
        {
            await _carRepository.RemoveAsync(carId);
        }
    }
}
