using System;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IBaseController : IDisposable
    {
        ExecuteResultEntity<Users> GetCurrentLoginUser();
        ExecuteResultEntity<Users> GetUser(string UserName);
        ExecuteResultEntity<Users> Login(LoginParameter model);
        ExecuteResultEntity<Users> Login(string UserName, string pwd);
    }
}