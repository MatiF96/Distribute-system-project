using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;

namespace CinemaSystem.Repositories
{
    public interface IShowingsRepository
    {
        Task<IList<Showing>> GetAll();
        Task<Showing> GetById(int showingId);
        Task<Showing> Add(Showing showing);
        Task<Showing> Edit(Showing showing);
        Task Delete(int showingId);
    }
}
