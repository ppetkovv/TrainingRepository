using MyTwitter.Data.Models;
using MyTwitter.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTwitter.Data.Repositories.Models
{
    class TweetRepository : GenericRepository<Tweet>, ITweetRepository
    {
        public TweetRepository(MyTwitterDbContext context) : base(context)
        {
        }

        public IEnumerable<Tweet> GetAllTwitterTweets(int twitterId)
        {
            return base.DbSet.Where()
        }
    }
}