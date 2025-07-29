using EMS.Common.HashPassword;
using EMS.Common.Token;
using EMS.Model.Enum;
using EMS.Model.ViewModel;
using EMS.Model.ViewModel.DTOs;
using EMS.Repository.IRepositories;
using EMS.Service.IServices;

namespace EMS.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHasher _login;
        private readonly ITokenService _tokenService;

        public AuthService(IEmployeeRepository employeeRepository, IPasswordHasher login, ITokenService tokenService)
        {
            _employeeRepository = employeeRepository;
            _login = login;
            _tokenService = tokenService;
        }

        public Response Login(LoginDto loginDto)
        {
            string msg;
            var employee = _employeeRepository.GetByEmail(loginDto.email);
            if (employee == null)
            {
                msg = string.Join(" ", MessageEnum.User_Not_Found.ToString().Split('_'));
                return new Response(404,msg, null);
            }

            bool isValid = _login.VerifyPassword(employee.Password, loginDto.Password);
            if (!isValid)
            {
                msg = string.Join(" ", MessageEnum.Invalid_Credentials.ToString().Split('_'));
                return new Response(401, msg, null);
            }

            employee.LastLogin = DateTime.UtcNow;
            _employeeRepository.Update(employee);

            var token = _tokenService.GenerateToken(employee);

            var data = new
            {
                employee.EmployeeId,
                employee.Name,
                employee.Age,
                employee.Email,
                Token = token
            };

            msg = string.Join(" ", MessageEnum.Login_Successful.ToString().Split('_'));
            return new Response(200, msg, data);
        }
    }
}
