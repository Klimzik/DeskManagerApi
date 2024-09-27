namespace DeskManagerApi.Models
{
    public class DeskOccupancyFilter
    {
        public int? FloorNumber { get; set; }
        public string? WorkerEmail { get; set; }
        public string? ReservationDate { get; set; }
    }
}