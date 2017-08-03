using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class UsersController : BaseController<IUsersRepository, Users>, IUsersController
    {
        public UsersController()
        {

        }

        public IExecuteResultEntity<Users> QueryByUserName(string username)
        {
            try
            {
                var repo = this.GetRepository<IUsersRepository,Users>();

                var result = from q in repo.All()
                             where q.UserName.Contains(username)
                             select q;

                return ExecuteResultEntity<Users>.CreateResultEntity(result.SingleOrDefault());
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Users>.CreateErrorResultEntity(ex);
            }
        }
    }
}
