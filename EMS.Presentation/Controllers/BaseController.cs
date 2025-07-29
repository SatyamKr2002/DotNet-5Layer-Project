using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EMS.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected string GetUsername()
        {
            return User?.FindFirstValue("Name") ?? "System";
        }

        protected int EmployeeId => int.Parse(User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        protected string Email => User?.FindFirstValue(ClaimTypes.Email);
        protected string Name => User?.FindFirstValue("Name") ?? "System";
        protected int Age => int.Parse(User?.FindFirstValue("Age") ?? "0");
        protected int DepartmentId => int.Parse(User?.FindFirstValue("DepartmentId") ?? "0");
    }
}
