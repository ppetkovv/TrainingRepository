using MyTwitter.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Data.Repositories.Contracts
{
    public interface ITweetRepository
    {
        IEnumerable<Tweet> GetAllTwitterTweets(int twitterId);
    }
}