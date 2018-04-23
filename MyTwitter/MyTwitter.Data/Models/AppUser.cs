using Microsoft.AspNetCore.Identity;
using MyTwitter.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Data.Models
{
    public class AppUser : IdentityUser, IUser
    {
        public ICollection<AppUserTwitterUser> TwitterUsers { get; set; }
    }
}