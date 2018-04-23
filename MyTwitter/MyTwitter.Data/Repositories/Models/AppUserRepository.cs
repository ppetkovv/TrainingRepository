using Microsoft.EntityFrameworkCore;
using MyTwitter.Data.Models;
using MyTwitter.Data.Models.Contracts;
using MyTwitter.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyTwitter.Data.Repositories.Models
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(MyTwitterDbContext context) : base(context)
        {
        }

        public IEnumerable<TwitterUser> GetAllFavouriteTwitterUsersById(string userId)
        {
            var r = base.DbSet.AsQueryable()
                .Include(user => user.TwitterUsers)
                    .ThenInclude(tu => tu.TwitterUser)
                .FirstOrDefault(user => user.Id == userId);

            return r.TwitterUsers.Select(t => t.TwitterUser);
        }
    }
}