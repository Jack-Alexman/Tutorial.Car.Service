namespace Tutorial.Car.DB.Schema.Models
{
    public class Car
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public string CarModel { get; set; }
        public string CompanyName { get; set; }
        public int Count { get; set; }
    }
}
