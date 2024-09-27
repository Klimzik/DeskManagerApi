﻿using DeskManagerApi.Models;

namespace DeskManagerApi.Services
{
    public interface IDeskOccupancyService
    {
        Task<DeskOccupancy> AddDeskOccupancyAsync(DeskOccupancy deskOccupancy);
        Task<List<DeskOccupancy>> GetAllDeskOccupanciesAsync();
        Task<DeskOccupancy> GetDeskOccupancyByIdAsync(int id);
        Task<bool> DeleteDeskOccupancyAsync(int id);
        Task<bool> UpdateDeskOccupancyAsync();
    }
}
