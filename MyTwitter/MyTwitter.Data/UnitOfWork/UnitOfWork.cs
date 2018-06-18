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
        private ITweetRepository tweetRepository;

        public UnitOfWork(MyTwitterDbContext context)
        {
            this.context = context;
        }

        public IAppUserRepository AppUserRepository => this.userRepository ??
            (this.userRepository = new AppUserRepository(this.context));

        public ITweetRepository TweetRepository => this.tweetRepository ??
            (this.tweetRepository = new TweetRepository(this.context));

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