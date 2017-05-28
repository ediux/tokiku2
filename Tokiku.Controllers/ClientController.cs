using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class ClientController : BaseController<ClientViewModel, Manufacturers>
    {
        public override ClientViewModel CreateNew()
        {
            ClientViewModel model = new ClientViewModel();

            var findlast = (from q in database.Manufacturers
                            where q.IsClient == true
                            orderby q.Code descending
                            select q).FirstOrDefault();

            if (findlast != null)
            {
                if (findlast.Code.StartsWith("CM"))
                {
                    int i = 0;

                    if (int.TryParse(findlast.Code.Substring(2), out i))
                    {
                        model.Code = string.Format("CM{0:000}", i + 1);
                    }
                }
            }
            else
            {
                model.Code = "CM001";
            }

            return model;
        }

        public ClientViewModelCollection QueryAll(Guid ProjectId)
        {
            var model = from q in database.Manufacturers
                        from p in q.Projects
                        where q.IsClient == true && q.Void == false && p.Id == ProjectId
                        select q;

            if (model.Any())
            {

            }

            ClientViewModelCollection collection = new ClientViewModelCollection();

            return collection;
        }
    }
}
