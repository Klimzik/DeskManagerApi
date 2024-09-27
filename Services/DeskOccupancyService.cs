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
