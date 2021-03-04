using BlazorJwtTest.Api.Token;
using BlazorJwtTest.Shared.Auth;
using BlazorJwtTest.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJwtTest.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public ServiceResponse<LoginResult> Login([FromBody] LoginModel loginModel) {
            if (loginModel.Username == "james" && loginModel.Password == "bond") {
                var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));
                string secret = _configuration["JwtSecurityKey"];
                var token = new JwtTokenBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create(secret))
                    .AddSubject("usertype_" + loginModel.LoginUserType)
                    .AddIssuer(_configuration["JwtIssuer"])
                    .AddAudience(_configuration["JwtAudience"])
                    .AddClaims(new Dictionary<string, string> {
                        { "username", loginModel.Username },
                        { "LoginUserType", loginModel.LoginUserType.ToString() }
                    })
                    .AddExpiry(expiry.Minute)
                    .Build();

                UserModel um = new UserModel() {
                    userid = Guid.NewGuid().ToString(),
                    username = "jamesbond",
                    fullname = "james bond",
                    role = loginModel.LoginUserType.ToString()
                };
                return new ServiceResponse<LoginResult> { 
                    Data= new LoginResult { user = um, Token = token.Value },
                    Status =true,
                    Message ="success"
                };
            } else {
                //return Unauthorized();
                return new ServiceResponse<LoginResult> {
                    Data = null,
                    Status = false,
                    Message = "Unauthorized"
                };
            }
        }

        [HttpGet]
        [Route("Ping")]
        public IActionResult Ping() {
            return Ok(new { result="pong" });
        }
    }
}
