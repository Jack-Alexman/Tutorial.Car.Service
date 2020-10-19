using System.Threading.Tasks;
using Tutorial.Car.Common.DTOs;
using Tutorial.Car.Common.Exceptions;
using Tutorial.Car.Common.IRepositories;

namespace Tutorial.Car.BL.Validators
{
    public interface ICarValidator
    {
        Task CanCreateAsync(CarDTO carDTO);
    }

    public class CarValidator: ICarValidator
    {
        private readonly ICarRepository _carRepository;

        public CarValidator(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task CanCreateAsync(CarDTO carDTO)
        {
            var modelTask = IsModelUnique(carDTO.CarModel);
            var descrTask = IsDescriptionUnique(carDTO.Description);

            await Task.WhenAll(modelTask, descrTask);
        }

        private async Task IsModelUnique(string model)
        {
            if (!await _carRepository.IsUniqueModelAsync(model))
            {
                throw new BusinessLogicException("Model error");
            }
        }

        private async Task IsDescriptionUnique(string description) {
            if (!await _carRepository.IsUniqueDescriptionAsync(description))
            {
                throw new BusinessLogicException("Description error");
            }
        }
    }
}
