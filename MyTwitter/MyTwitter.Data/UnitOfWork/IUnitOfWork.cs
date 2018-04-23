﻿using MyTwitter.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAppUserRepository AppUserRepository { get; }

        void SaveChanges();

        void SaveChangesAsync();
    }
}