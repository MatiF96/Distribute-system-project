using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;

namespace CinemaSystem.Repositories
{
    public interface IHalesRepository
    {
        Task<IList<Hall>> GetAll();
        Task<Hall> GetById(int hallId);
        Task<Hall> Add(Hall hall);
        Task<Hall> Edit(Hall hall);
        Task<int?> Delete(int hallId);
        Task<IList<Showing>> GetShowings(int hallId);
    }
}
