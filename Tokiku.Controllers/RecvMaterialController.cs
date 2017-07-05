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

        public ExecuteResultEntity<ICollection<RecvMaterialEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<RecvMaterialEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<RecvMaterialEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<RecvMaterialEntity>>.CreateResultEntity(
                        new Collection<RecvMaterialEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<RecvMaterialEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
