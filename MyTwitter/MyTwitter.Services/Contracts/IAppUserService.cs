using MyTwitter.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Services.Contracts
{
    public interface IAppUserService
    {
        IEnumerable<TwitterUser> GetAllFavouriteTwittersForUser(string userId);
    }
}