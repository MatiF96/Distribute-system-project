using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
