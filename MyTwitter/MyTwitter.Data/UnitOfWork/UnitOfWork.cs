using MyTwitter.Data.Repositories.Contracts;
using MyTwitter.Data.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyTwitterDbContext context;

        private IAppUserRepository userRepository;

        public UnitOfWork(MyTwitterDbContext context)
        {
            this.context = context;
        }

        public IAppUserRepository AppUserRepository => this.userRepository ??
            (this.userRepository = new AppUserRepository(this.context));

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            this.context.SaveChangesAsync();
        }
    }
}