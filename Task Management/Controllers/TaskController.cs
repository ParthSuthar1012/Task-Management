using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;
using Task_Management.Data;
using Task_Management.Models;
using Task_Management.Models.NewFolder;

namespace Task_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
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
            var role = await _context.Roles.FirstOrDefaultAsync(a => a.RoleID == user.RoleID);
            // Check if the user has the necessary role
            if (role.RoleName.ToString() != "Developer" && role.RoleName != "Manager" && role.RoleName!="Admin" && role.RoleName!="Team Lead")
                return Forbid();

            var task = new Models.Task
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Status = model.Status,
                Priority = model.Priority,
                CreatedBy = user.UserId,
                CreatedAt = DateTime.Now,
            };
          

            var assignUser = new List<Assignedto>();

            foreach (var assignedUserId in model.AssignedTo)
            {
                var userId = _context.Users.FirstOrDefault(a => a.UserId == assignedUserId.UserId);
                var userRole = await _context.Roles.FirstOrDefaultAsync(a => a.RoleID == userId.RoleID);

                if (userId == null)
                {
                    return BadRequest("User Not Found");
                }
                if(userId.RoleID < user.RoleID)
                {
                    return BadRequest("Can Not assign to this user ");
                }
                var assignto = new Assignedto { UserId = assignedUserId.UserId };
                assignUser.Add(assignto);

                task.AssignedToUsers = assignUser;
            }
            _context.tasks.Add(task);
           
            await _context.SaveChangesAsync();

            return Ok("Task added Successfully.");
        }



        [HttpGet]
        [Route("GetTask")]
        [Authorize]
        public async Task<IActionResult> GetTask()
        {

            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var username = claim.Value;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            var userRole = await _context.Roles.FirstOrDefaultAsync(a => a.RoleID == user.RoleID);
            var list = await _context.tasks.Include(o => o.AssignedToUsers).ThenInclude(oa => oa.AssignUser).ToListAsync();
            if (user == null)
                return Unauthorized();
            if (userRole.RoleName != "Admin")
          
            {
                var Assigned = await _context.AssignedUser.Where(a => a.UserId == user.UserId).ToListAsync();
                 list = await _context.tasks.Include(o => o.AssignedToUsers).ThenInclude(oa => oa.AssignUser).Where(u => u.CreatedByUser.UserId == user.UserId).ToListAsync();
                if (Assigned.Count() > 0)
                {
                    foreach (var item in Assigned)
                    {
                        var dataList = await _context.tasks.Include(o => o.CreatedByUser).FirstOrDefaultAsync(u => u.TaskId == item.TaskId);
                        list.Add(dataList);
                    }
                }
            }

            var FinalList = list.Select(u => new 
           {
               TaskId=u.TaskId,
               Title = u.Title,
               Description = u.Description,
               DueDate = u.DueDate,
               Status = u.Status.ToString(),
               Priority=u.Priority.ToString(),
               CreatedBy=u.CreatedByUser.Name.ToString(),
               AssignedToUsers=u.AssignedToUsers.Select(o=>o.AssignUser.UserName).ToList(),
               CreatedAt=u.CreatedAt,
            });
           return Ok(FinalList);
          
        }
    }

}
