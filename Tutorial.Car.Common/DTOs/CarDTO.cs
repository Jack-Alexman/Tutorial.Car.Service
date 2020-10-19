using Tutorial.Car.Common.DTOs.Base;

namespace Tutorial.Car.Common.DTOs
{
    public class CarDTO: BaseItemDTO
    {
        public string Description { get; set; }
        public string CarModel { get; set; }
        public string CompanyName { get; set; }
        public int Count { get; set; }
    }
}
