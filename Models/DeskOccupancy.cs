namespace DeskManagerApi.Models
{
    public class DeskOccupancy
    {
        public int Id { get; set; }
        public string DeskNumber { get; set; } // Numer biurka
        public int FloorNumber { get; set; }   // Numer piętra
        public string WorkerEmail { get; set; } // Email pracownika
        public DateTime OccupiedAt { get; set; } = DateTime.Now; // Data zajęcia
    }
}
