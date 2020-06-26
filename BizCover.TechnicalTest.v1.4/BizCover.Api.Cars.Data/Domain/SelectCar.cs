namespace BizCover.Cars.Data.Domain
{
    public class SelectCar
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string CountryManufactured { get; set; }
        public string Colour { get; set; }
        public double Price { get; set; }
    }
}
