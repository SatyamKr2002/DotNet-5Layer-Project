using EMS.Model.ViewModel.DTOs;
using EMS.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            var response = _authService.Login(loginDto);
            if (response.StatusCode == 200)
            {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }
    }
}
