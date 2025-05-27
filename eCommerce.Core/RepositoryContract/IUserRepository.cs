﻿using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.RepositoryContract
{
    public interface IUserRepository
    {

        Task<ApplicationUser> AddUser(ApplicationUser? user);

        Task<ApplicationUser> FindUser(string? Email, string? Password);


    }
}
