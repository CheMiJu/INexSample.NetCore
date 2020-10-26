using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtToken.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JwtToken.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenHelper _tokenHelper;

        public AuthController(TokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }
                
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginReqeust reqeust)
        {
            bool authorized = true;
            //Your UAuthentication flow
            //bool authorized = AuthenticationUser(request.UserName, request.Password);

            if (authorized)
            {
                var token = _tokenHelper.GenerateJWTToken(reqeust.UserName);

                return Ok(new
                {
                    token = token
                });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        public IActionResult GetClaims()
        {
            return Ok(
                    User.Claims.Select(x => new { x.Type, x.Value })
                ); ;
        }
    }
}
