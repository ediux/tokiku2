using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class RecvMaterialController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<Receive>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<Receive>> rtn;

            try
            {
                var repo = RepositoryHelper.GetReceiveRepository();
                return ExecuteResultEntity<ICollection<Receive>>.CreateResultEntity(
                    new Collection<Receive>(repo.All().ToList()))
;
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<Receive>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
