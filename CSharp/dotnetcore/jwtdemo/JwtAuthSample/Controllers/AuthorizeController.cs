using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
namespace JwtAuthSample
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController:Controller
    {
        JwtSettings jwtSettings;
        public AuthorizeController(IOptions<JwtSettings> options)
        {
            jwtSettings = options.Value;
        }
        public IActionResult Token(LoginViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                //生成 token
                if(!(viewModel.User.Equals("lsd") && viewModel.Password.Equals("123456")))
                    return BadRequest();
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name,viewModel.User),
                    new Claim(ClaimTypes.Role,viewModel.User),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
                var crdes = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(jwtSettings.Issuer,jwtSettings.Audience
                    ,claims,DateTime.Now
                    ,DateTime.Now.AddMinutes(30)
                    ,crdes
                );
                return Ok(new {token= new JwtSecurityTokenHandler().WriteToken(token)});
            }
            return BadRequest();
        }
    }
}