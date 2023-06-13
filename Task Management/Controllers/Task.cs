using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Task_Management.Data;
using Task_Management.Models;
using Task_Management.Models.NewFolder;

namespace Task_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Task(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("AddTask")]
        [Authorize]
        public async Task<IActionResult> CrateTask(Taskvm model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var username = claim.Value;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
                return Unauthorized();
            var role = await _context.Roles.FirstOrDefaultAsync(a=>a.RoleID==user.RoleID);  
            // Check if the user has the necessary role
            if (role.RoleName != "Developer" && role.RoleName != "Manager")
                return Forbid();

            var task = new Models.Task
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Status = model.Status,
                Priority = model.Priority,
                AssignedTo = model.AssignedTo,
                CreatedBy = model.CreatedBy,
                CreatedAt = DateTime.Now,
            };

            _context.tasks.Add(task);
            await _context.SaveChangesAsync();

            return Ok(task);
        }
    }
}
