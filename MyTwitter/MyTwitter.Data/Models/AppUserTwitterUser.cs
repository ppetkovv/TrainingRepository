using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Data.Models
{
    public class AppUserTwitterUser
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string TwitterUserId { get; set; }
        public TwitterUser TwitterUser { get; set; }
    }
}
