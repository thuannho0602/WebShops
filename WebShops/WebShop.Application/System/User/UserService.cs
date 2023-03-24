using Demo.DataBase.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebShop.ViewModels.System.User;
using WebShops.Utilities.Exceptions;

namespace WebShop.Application.System.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser>userManager,SignInManager<AppUser> signInManager,RoleManager<AppRole> roleManager,IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<string> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return null;
            }
            var result = await _signInManager.PasswordSignInAsync(user,request.Password,request.RememberMe,true);
            if (!result.Succeeded)
            {
                return null;
            }
            var role= await  _userManager.GetRolesAsync(user);
            
            //Tao Ra Claim
            var claim = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role,string.Join(";",role))
            };

            //Mã hóa Claim 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claim,
                expires: DateTime.Now.AddDays(3),
                signingCredentials:creds);
            return new JwtSecurityTokenHandler().WriteToken(token) ;
        
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new AppUser()
            {
                DOB = request.DOB,
                Email=request.Email,
                FirstName=request.FirstName,
                LastName=request.LastName,
                UserName=request.UserName,
                PhoneNumber=request.PhoneNumber,

            };

            var reults = await _userManager.CreateAsync(user, request.Password);
            if (reults.Succeeded)
            {
                return true;
            }
             return false;
            
        }
    }
}
