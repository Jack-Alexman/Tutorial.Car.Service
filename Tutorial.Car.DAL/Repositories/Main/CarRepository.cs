using Dapper;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutorial.Car.Common.DTOs;
using Tutorial.Car.Common.IRepositories;
using Tutorial.Car.DAL.Helpers;
using Tutorial.Car.DAL.Queries;

namespace Tutorial.Car.DAL.Repositories.Main
{
    public class CarRepository : ICarRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IHelperRepository _helperRepository;

        public CarRepository(IConnectionFactory connectionFactory,
                             IHelperRepository helperRepository)
        {
            _connectionFactory = connectionFactory;
            _helperRepository = helperRepository;
        }

        public async Task<CarDTO[]> GetAllAsync()
        {              
            using (var connection = _connectionFactory.GetOpenedConnection())
            {
                try
                {
                    return await connection.QueryArrayAsync<CarDTO>(CarQueries.GetAll);
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<CarDTO> CreateAsync(CarDTO channelDTO)
        {
            return await _helperRepository.InsertAsync(CarQueries.Create, channelDTO);
        }

        public async Task<bool> IsUniqueModelAsync(string model)
        {
            using (var connection = _connectionFactory.GetOpenedConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<bool>(CarQueries.IsUniqueModel, new { CarModel = model });
            }
        }

        public async Task<bool> IsUniqueDescriptionAsync(string description)
        {
            using (var connection = _connectionFactory.GetOpenedConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<bool>(CarQueries.IsUniqueDescription, new { Description = description });
            }
        }
        public async Task RemoveAsync(long carId)
        {
            await _helperRepository.DeleteAsync(carId, "Channels");
        }

        //public async Task RemoveAsync(long carId)
        //{
        //    using (var connection = _connectionFactory.GetOpenedConnection())
        //    {               
        //        await connection.QueryFirstOrDefaultAsync(CarQueries.Remove);                
        //    }
        //}
    }
}
