using Microsoft.EntityFrameworkCore;

namespace CinemaSystem.Services
{
    public class BaseService
    {
        private readonly DbContext _ctx;

        public BaseService(DbContext ctx)
        {
            _ctx = ctx;
        }
    }
}
