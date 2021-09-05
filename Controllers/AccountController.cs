using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pegasus.Models.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	[ApiConventionType(typeof(DefaultApiConventions))]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class AccountController : ControllerBase {

		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IConfiguration _config;

		public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration config) {
			_signInManager = signInManager;
			_userManager = userManager;
			_config = config;
		}

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="model">The login details</param>	 
		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult<String>> CreateToken(LoginDTO model) {
			var user = await _userManager.FindByNameAsync(model.Email);

			if (user != null) {
				var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

				if (result.Succeeded) {
					string token = GetToken(user);
					return Created("", token); //returns only the token                    
				}
			}
			return BadRequest();
		}

		/// <summary>
		/// Checks if an email is available as username
		/// </summary>
		/// <returns>True if the email is not registered yet</returns>
		/// <param name="email">Email.</param>/
		[HttpGet("checkusername")]
		public async Task<ActionResult<Boolean>> CheckAvailableUserName(string email) {
			var user = await _userManager.FindByNameAsync(email);
			return user == null;
		}

		/// <summary>
		/// Register a user
		/// </summary>
		/// <param name="model">The user details</param>
		/// <returns></returns>
		[HttpPost("register")]
		public async Task<ActionResult<String>> Register(RegisterDTO model) {
			IdentityUser user = new IdentityUser { UserName = model.Email, Email = model.Email };
			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded) {
				string token = GetToken(user);
				return Created("", token);
			}
			return BadRequest();
		}

		private String GetToken(IdentityUser user) {
			// Create the token
			var claims = new[]
			{
			  new Claim(JwtRegisteredClaimNames.Sub, user.Email),
			  new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
			  null, null,
			  claims,
			  expires: DateTime.Now.AddMinutes(30),
			  signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
