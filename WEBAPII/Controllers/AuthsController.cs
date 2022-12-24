using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {

        IUserService _userService;
    
        public AuthsController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("login")]
        public IActionResult getcustomerlogin(UserForLogin userForLogin)
        {
            var user = _userService.getByEmail(userForLogin);
            
            if (user.Success)
            {
                if (!(user.Data.Email==userForLogin.email && user.Data.Password==userForLogin.password))
                {
                    return BadRequest(user);
                }
                return Ok(user);
            }

      

            return BadRequest(user);

        }

        [HttpPost("logindadmin")]
        public IActionResult adminlogin(UserForLogin userForLogin)
        {
            var admin = _userService.getAdmin(userForLogin);

            if (admin.Success)
            {
                return Ok(admin);
            }

            return BadRequest(admin);

        }

    }
}
