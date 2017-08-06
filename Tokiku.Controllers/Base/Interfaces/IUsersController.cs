using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.Controllers
{
    public interface IUsersController : IViewController
    {
        IExecuteResultEntity<Users> QueryByUserName(string username);
    }
}