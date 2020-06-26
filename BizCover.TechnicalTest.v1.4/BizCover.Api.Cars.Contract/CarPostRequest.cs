using System.ComponentModel.DataAnnotations;

namespace BizCover.Cars.Contract
{
    public class CarPostRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please supply a valid Make. Its empty!")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Please supply a valid Model. Its empty!")]
        public string Model { get; set; }
        [Range(1908, int.MaxValue, ErrorMessage = "Please supply a valid Year >= 1908. A bit of trivia: The first production car was created in 1908 although Karl Benz created the car in 1886.")]
        public int Year { get; set; }
        public string CountryManufactured { get; set; }
        [Required(ErrorMessage = "Please supply a valid Colour. Its empty!")]
        public string Colour { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please supply a valid Price. It should be positive!")]
        public decimal Price { get; set; }

    }
}
