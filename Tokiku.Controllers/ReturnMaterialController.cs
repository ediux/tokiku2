using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ReturnMaterialController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<ReturnMaterialEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<ReturnMaterialEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<ReturnMaterialEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<ReturnMaterialEntity>>.CreateResultEntity(
                        new Collection<ReturnMaterialEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<ReturnMaterialEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
