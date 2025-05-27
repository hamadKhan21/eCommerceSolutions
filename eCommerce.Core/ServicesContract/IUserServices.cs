using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServicesContract
{
    public interface IUserServices
    {
        Task<AuthenticationResponse> Login(LoginReguest loginReguest);

        Task<AuthenticationResponse> Register(RegisterRequest registerRequest);
    }
}
