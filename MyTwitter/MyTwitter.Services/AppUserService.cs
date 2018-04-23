using MyTwitter.Data.UnitOfWork;
using MyTwitter.Providers;
using MyTwitter.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyTwitter.Data.Models;

namespace MyTwitter.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingProvider mappingProvider;

        public AppUserService(IUnitOfWork unitOfWork, IMappingProvider mappingProvider)
        {
            if (unitOfWork == null || mappingProvider == null)
            {
                throw new ArgumentNullException();
            }

            this.unitOfWork = unitOfWork;
            this.mappingProvider = mappingProvider;
        }

        public IEnumerable<TwitterUser> GetAllFavouriteTwittersForUser(string userId)
        {
            return this.unitOfWork.AppUserRepository.GetAllFavouriteTwitterUsersById(userId);
        }
    }
}