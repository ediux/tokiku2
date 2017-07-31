using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ConstructionAtlasController : BaseController<ConstructionAtlas>
    {
        public ExecuteResultEntity<ICollection<ConstructionAtlas>> SearchByText(string text)
        {
            try
            {
                if (text != null && text.Length > 0)
                {
                    

                    //return model;
                    var repo = this.GetRepository();
                    var result = from q in repo.All()
                                 where q.ImageName.Contains(text)
                                 || q.ReplyNumber.Contains(text)
                                 || q.SubmitCertificateNumber.Contains(text)
                                 select q;

                    return ExecuteResultEntity<ICollection<ConstructionAtlas>>
                         .CreateResultEntity(new Collection<ConstructionAtlas>(result.ToList()));
                }
                else
                {
                    var result = QueryAll();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ConstructionAtlas>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<ConstructionAtlas>> QueryAll()
        {
            try {
                var repo = this.GetRepository();
                return ExecuteResultEntity<ICollection<ConstructionAtlas>>.CreateResultEntity(
                    new Collection<ConstructionAtlas>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<ConstructionAtlas>>.CreateErrorResultEntity(ex);
            }
        }

    }
}
