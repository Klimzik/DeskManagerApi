using System.ComponentModel.DataAnnotations;

namespace DeskManagerApi.Models
{
    public class DeskOccupancy
    {
        [Key]
        public int? Id { get; set; }
        public int FloorNumber { get; set; } 
        public int DeskNumber { get; set; }
        public string WorkerEmail { get; set; }
        public DateTime ReservationDate { get; set; } 
        public bool IsOccupated { get; set; }
    }
}