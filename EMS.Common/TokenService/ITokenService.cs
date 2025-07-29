using EMS.Model.DataModel;

namespace EMS.Common.Token
{
    public interface ITokenService
    {
        string GenerateToken(Employee employee);
    }
}
