using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;
using CinemaSystem.Repositories;
using CinemaSystem.Services.DTO;

namespace CinemaSystem.Services
{
    public class HalesService : IHalesService
    {
        private readonly IHalesRepository _halesRepository;

        public HalesService(IHalesRepository halesRepository)
        {
            _halesRepository = halesRepository;
        }

        public async Task<HallDto> AddHall(AddEditHallDto hall)
        {
            var newHall = new Hall {
                HallName = hall.Name
            };
            var result = await _halesRepository.Add(newHall);
            return new HallDto(result);
        }

        public async Task<int?> DeleteHall(int hallId)
        {
            return await _halesRepository.Delete(hallId);
        }

        public async Task<HallDto> EditHall(int hallId, AddEditHallDto hall)
        {
            var editedHall = await _halesRepository.GetById(hallId);
            if (editedHall == null) return null;
            editedHall.HallName = hall.Name;
            var result = await _halesRepository.Edit(editedHall);
            return new HallDto(result);
        }

        public async Task<HallDto> GetById(int hallId)
        {
            var result = await _halesRepository.GetById(hallId);
            if (result == null) return null;
            return new HallDto(result);
        }

        public async Task<IList<HallDto>> GetHales()
        {
            var hales = await _halesRepository.GetAll();
            return hales.Select(h => new HallDto(h)).ToList();
        }
    }
}
