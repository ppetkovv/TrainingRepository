using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Data.Models
{
    public class Tweet
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public int Replies { get; set; }

        public int Retweets { get; set; }

        public int Likes { get; set; }

        public TwitterUser Twitter { get; set; }
    }
}