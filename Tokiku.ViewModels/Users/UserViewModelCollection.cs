using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class UserViewModelCollection : BaseViewModelCollection<UserViewModel>
    {
        public UserViewModelCollection()
        {

        }

        public UserViewModelCollection(IEnumerable<UserViewModel> source):base(source)
        {

        }

        public static UserViewModelCollection Query()
        {
            try
            {
                var coll = Query<UserViewModelCollection, Users>("SystemMembers", "Query");
                return coll;
            }
            catch (Exception ex)
            {
                UserViewModelCollection collection = new UserViewModelCollection();
                setErrortoModel(collection, ex);
                return collection;
            }
        }
    }
}
