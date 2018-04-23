using MyTwitter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyTwitter.Data.Repositories.Contracts
{
    public interface IAppUserRepository
    {
        IEnumerable<TwitterUser> GetAllFavouriteTwitterUsersById(string userId);
    }
}