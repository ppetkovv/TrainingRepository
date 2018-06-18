using MyTwitter.Data.Models;
using MyTwitter.Data.UnitOfWork;
using MyTwitter.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Services
{
    class TweetService : ITweetService
    {
        private IUnitOfWork unitOfWork;

        public TweetService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Tweet> GetAllTwitterTweets()
        {
            return this.unitOfWork
        }
    }
}