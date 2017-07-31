using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class UsersController : BaseController<Users>
    {
        public ExecuteResultEntity<Users> QueryByUserName(string username)
        {
            try
            {
                var repo = this.GetRepository();

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
