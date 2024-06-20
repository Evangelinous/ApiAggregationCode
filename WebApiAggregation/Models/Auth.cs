using System.Collections.Generic;

namespace WebApiAggregation.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseBaseModel<T>
    {
        public T Data { get; set; }
        public List<Error> Errors { get; set; } = new List<Error>();

        public LoginResponseBaseModel(T data)
        {
            Data = data;
        }
    }

    public class Error
    {
        public string ErrorType { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }

    public class UserDataModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<string> Roles { get; set; }
    }
}
