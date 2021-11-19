using CarDealer.Models;
using System.Collections.Generic;

namespace CarDealer.DTO.Input
{
    public class CarInputModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int TravelledDistance { get; set; }
        public IEnumerable<int> PartsId { get; set; } = new List<int>();
    }
}
