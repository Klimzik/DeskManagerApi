using DeskManagerApi.Data;
using DeskManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DeskManagerApi.Services
{
    public class DeskOccupancyService : IDeskOccupancyService
    {
        private readonly AppDbContext _context;

        public DeskOccupancyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeskOccupancy> AddDeskOccupancyAsync(DeskOccupancy deskOccupancy)
        {
            _context.DeskOccupancies.Add(deskOccupancy);
            await _context.SaveChangesAsync();
            return deskOccupancy;
        }

        public async Task<List<DeskOccupancy>> GetAllDeskOccupanciesAsync()
        {
            return await _context.DeskOccupancies.ToListAsync();
        }

        public async Task<List<DeskOccupancy>> GetFilteredDeskOccupanciesAsync(DeskOccupancyFilter filter)
        {
            var query = _context.DeskOccupancies.AsQueryable();

            if (filter.FloorNumber.HasValue)
            {
                query = query.Where(d => d.FloorNumber == filter.FloorNumber.Value);
            }

            if (!string.IsNullOrEmpty(filter.WorkerEmail))
            {
                query = query.Where(d => d.WorkerEmail == filter.WorkerEmail);
            }

            if (!string.IsNullOrEmpty(filter.ReservationDate) && DateTime.TryParse(filter.ReservationDate, out var reservationDate))
            {
                var utcReservationDate = DateTime.SpecifyKind(reservationDate, DateTimeKind.Utc);

                query = query.Where(d => d.ReservationDate.Date == utcReservationDate.Date);
            }

            return await query.ToListAsync();
        }

        public async Task<DeskOccupancy> GetDeskOccupancyByIdAsync(int id)
        {
            return await _context.DeskOccupancies.FindAsync(id);
        }

        public async Task<bool> DeleteDeskOccupancyAsync(int id)
        {
            var deskOccupancy = await _context.DeskOccupancies.FindAsync(id);
            if (deskOccupancy == null)
            {
                return false;
            }

            _context.DeskOccupancies.Remove(deskOccupancy);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDeskOccupancyAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}