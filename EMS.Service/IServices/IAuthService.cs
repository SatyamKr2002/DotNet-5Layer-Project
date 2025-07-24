using EMS.Model.ViewModel;
using EMS.Model.ViewModel.DTOs;

namespace EMS.Service.IServices
{
    public interface IAuthService
    {
        public Response Login(LoginDto loginDto);
    }
}
