using MyTwitter.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Data.Models
{
    public class TwitterUser : IUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Tweets { get; set; }
        public int Following { get; set; }
        public int Followers { get; set; }
        public int Likes { get; set; }
        public ICollection<AppUserTwitterUser> AppUsers { get; set; }
        public ICollection<Tweet> TweetsCollection { get; set; }
    }
}