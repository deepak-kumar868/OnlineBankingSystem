
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using DALayer;
using DALayer.Models;
using EntityLayer;
using System.Text;

using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UILayer.Controllers

{

    //[Route("api/[controller]")]

    [ApiController]

    public class AuthenticationWebApiController : ControllerBase
    {
        private IUser Uservice;
        public AuthenticationWebApiController(IUser Uservice)
        {
            this.Uservice = Uservice;
        }



        private string CreateToken(string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefghijklmnopqrst"));
            var CredentialInfo = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var clm = new List<Claim>();
            clm.Add(new Claim(ClaimTypes.Role, role));
            var token = new JwtSecurityToken(
            issuer: "http://localhost:11646",
            audience: "http://localhost:11646",
            expires: DateTime.Now.AddDays(5),
            claims: clm,
            signingCredentials: CredentialInfo
            );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }



        [HttpPost("ValidateUser")]

        public async Task<IActionResult> ValidateUser(UserModel user)
        {
            TokenDetail tdel = new TokenDetail();
            var userData = await Uservice.GetValidUser(user);
            if (userData != null)
            {
                var token = CreateToken(userData.Role);
                tdel.UserName = userData.UserName;
                tdel.Role = userData.Role;
                tdel.Token = token;
                SaveToken(token);
                return Ok(tdel);
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }

        }


        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(CredentialModel user)
        {
            try
            {
                TokenDetail tdel = new TokenDetail();
                var userData = await Uservice.RegisterUser(user);
                if (userData != null)
                {
                    var token = CreateToken(user.Role);
                    tdel.UserName = user.UserName;
                    tdel.Role = user.Role;
                    tdel.Token = token;
                    return Ok(tdel);
                }
                else
                {
                    return BadRequest("Registration Failed");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private void SaveToken(string token)
        {
            HttpContext.Response.Cookies.Append("Jwt", token);
        }
    }

}







