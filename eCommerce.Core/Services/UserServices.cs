using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Core.ServicesContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    internal class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResponse> Login(LoginReguest loginReguest)
        {
          
            var user=await _userRepository.FindUser(loginReguest.Email, loginReguest.Password);

            if (user != null)
            {
               AuthenticationResponse userdetails = new AuthenticationResponse(
                   user.UserID,user.Email,user.PersonName,user.Gender.ToString(),"Token Generated",true
                   );

                return userdetails;
            }
            else
            {
                return null;
            }
        }

        public async Task<AuthenticationResponse> Register(RegisterRequest registerRequest)
        {
            ApplicationUser user = new ApplicationUser() {
                UserID = new Guid(),
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                PersonName = registerRequest.PersonName,
                Gender = registerRequest.Gender
            };



            var result=await _userRepository.AddUser(user);


            return  new AuthenticationResponse(
                new Guid(), result.Email, result.PersonName, result.Gender.ToString(), "", true);
        }
    }
}
