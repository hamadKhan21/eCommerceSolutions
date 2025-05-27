using eCommerce.Core.DTO;
using eCommerce.Core.ServicesContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest regRequest)
        {
            if(regRequest == null)
            {

                return BadRequest("Invalid Data");
            }
            else
            {

                var result=await _userServices.Register(regRequest);

                return Ok(result);
            }


           
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReguest login)
        {

            if(login == null || login.Email==null || login.Password==null)
            {

                return Unauthorized("User not authorized");
            }
            else
            {

                var result = await _userServices.Login(login);  

                return Ok(result);
            }


           
        }



    }
}
