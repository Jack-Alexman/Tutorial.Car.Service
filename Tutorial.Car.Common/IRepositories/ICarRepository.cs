using System.Threading.Tasks;
using Tutorial.Car.Common.DTOs;

namespace Tutorial.Car.Common.IRepositories
{
    public interface ICarRepository
    {
        Task<CarDTO[]> GetAllAsync();
        Task<CarDTO> CreateAsync(CarDTO channelDTO);
        Task<bool> IsUniqueModelAsync(string model);
        Task<bool> IsUniqueDescriptionAsync(string description);
        Task RemoveAsync(long carId);
    }
}
