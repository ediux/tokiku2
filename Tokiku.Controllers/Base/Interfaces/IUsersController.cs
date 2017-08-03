using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IUsersController : IBaseController<Users>
    {
        IExecuteResultEntity<Users> QueryByUserName(string username);
    }
}