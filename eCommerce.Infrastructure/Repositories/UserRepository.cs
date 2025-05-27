using eCommerce.Core.Entities;
using eCommerce.Core.Enum;
using eCommerce.Core.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public async Task<ApplicationUser> AddUser(ApplicationUser? user)
        {
            user.UserID = Guid.NewGuid();
            user.Gender = GenderOption.Male;
            user.Password= "123456";    
            user.Email= "lXeMj@example.com";
            user.PersonName= "ABC";



            return user;
        }

        public async Task<ApplicationUser> FindUser(string Email, string Password)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserID = Guid.NewGuid(),
            Gender = GenderOption.Male,
            Password = "123456",
            Email = "lXeMj@example.com",
            PersonName = "ABC"

        };

            return user;
           
        }
    }
}
