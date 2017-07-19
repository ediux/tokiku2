using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ConstructionAtlasController : BaseController
    {
        public ExecuteResultEntity<ICollection<ConstructionAtlas>> SearchByText(string text)
        {
            try
            {
                if (text != null && text.Length > 0)
                {
                    //ExecuteResultEntity<ICollection<ConstructionAtlas>> model = ExecuteResultEntity<ICollection<ConstructionAtlas>>
                    //     .CreateResultEntity(new Collection<ConstructionAtlas>(result.ToList()));

                    //return model;
                    return null;
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
                var repo = RepositoryHelper.GetConstructionAtlasRepository();
                return ExecuteResultEntity<ICollection<ConstructionAtlas>>.CreateResultEntity(
                    new Collection<ConstructionAtlas>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<ConstructionAtlas>>.CreateErrorResultEntity(ex);
            }
        }

    }
}
