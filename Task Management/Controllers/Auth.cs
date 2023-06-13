using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task_Management.Data;
using Task_Management.Models;
using Task_Management.Models.NewFolder;

namespace Task_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public Auth(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> Register(registerVm model)
        {
            

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == model.UserName.ToLower());
            var exssistingEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == model.Email.ToLower());
            if (existingUser != null)
            {
                return BadRequest("Username already exists");
            }
            if ( exssistingEmail != null)
            {
                return BadRequest("email is used, enter another email");
            }
            if ( model.UserName == model.Password)
            {
                return BadRequest("UserNmae and Password Can't Be Same");
            }
            var role =  await _context.Roles.FirstOrDefaultAsync(a => a.RoleID == model.RoleID); 
            if (role == null) {
                return BadRequest("Given Role Is Not exist");
            }
            var user = new User { 
             UserName = model.UserName,
             Email = model.Email,
             Password = model.Password,
             RoleID = model.RoleID,
             Name = model.Name,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User Added Successfully");
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> Role(Roles model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var existingRole = await _context.Roles.FirstOrDefaultAsync(a => a.RoleName.ToLower() == model.RoleName.ToLower()); 
            if(existingRole != null)
            {
                return BadRequest("Role exists");
            } 

            _context.Roles.Add(model);
            await _context.SaveChangesAsync();
            return Ok("Role Added");

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(loginvm model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.Users.FirstOrDefaultAsync(a => a.UserName == model.UserName);

            if (user == null) {
                return BadRequest("User Don't Exist");
            }
            if (user.Password != model.Password)
            {
                return BadRequest("Password Is Wrong");
            }
            var token = GenerateJwtToken(model.UserName);
            return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });

        }

        private JwtSecurityToken GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var authClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: authClaims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }


}
