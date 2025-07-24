namespace EMS.Model.Enum
{
    public enum MessageEnum
    {
        Success,      // 200
        Created,     // 201
        Not_Found,   // 404
        ServerError, // 500 status code
        Unauthorized,  // 401
        User_Not_Found,
        Invalid_Credentials,
        Login_Successful
    }
}
