﻿using DeskManagerApi.Models;
using DeskManagerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskOccupancyController : ControllerBase
    {
        private readonly DeskOccupancyService _deskOccupancyService;

        public DeskOccupancyController(DeskOccupancyService deskOccupancyService)
        {
            _deskOccupancyService = deskOccupancyService;
        }

        [HttpPost]
        public async Task<ActionResult<DeskOccupancy>> AddDeskOccupancy(DeskOccupancy deskOccupancy)
        {
            deskOccupancy.ReservationDate = DateTime.UtcNow;
            var addDeskOccupancy = await _deskOccupancyService.AddDeskOccupancyAsync(deskOccupancy);

            return Ok(addDeskOccupancy);
        }

        [HttpPost("Filtered")]
        public async Task<ActionResult<List<DeskOccupancy>>> GetFilteredDesksOccupancies([FromBody] DeskOccupancyFilter filter)
        {
            var deskOccupancies = await _deskOccupancyService.GetFilteredDeskOccupanciesAsync(filter);
            return Ok(deskOccupancies);
        }

        [HttpGet]
        public async Task<ActionResult<List<DeskOccupancy>>> GetDesksOccupancie()
        {
            var deskOccupancies = await _deskOccupancyService.GetAllDeskOccupanciesAsync();
            return Ok(deskOccupancies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeskOccupancy>> GetDeskOccupancyById(int id)
        {
            var deskOccupancy = await _deskOccupancyService.GetDeskOccupancyByIdAsync(id);
            if (deskOccupancy == null)
            {
                return NotFound();
            }
            return Ok(deskOccupancy);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeskOccupancy>> DeleteDeskOccupancy(int id)
        {
            var deskOccupancy = await _deskOccupancyService.GetDeskOccupancyByIdAsync(id);
            if (deskOccupancy == null)
            {
                return NotFound();
            }

            await _deskOccupancyService.DeleteDeskOccupancyAsync(id);

            return Ok();
        }

        [HttpPut("Release/{id}")]
        public async Task<ActionResult<DeskOccupancy>> ReleaseDeskOccupancy(int id)
        {
            var deskOccupancy = await _deskOccupancyService.GetDeskOccupancyByIdAsync(id);
            if (deskOccupancy == null)
            {
                return NotFound();
            }

            deskOccupancy.IsOccupated = false;
            await _deskOccupancyService.UpdateDeskOccupancyAsync();

            return deskOccupancy;
        }

    }
}