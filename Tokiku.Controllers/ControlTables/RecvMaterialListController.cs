using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;

namespace Tokiku.Controllers
{
    public class RecvMaterialListController : ControllerBase
    {
        private string sql;

        public ExecuteResultEntity<ICollection<RecvMaterialListEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<RecvMaterialListEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<RecvMaterialListEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<RecvMaterialListEntity>>.CreateResultEntity(
                        new Collection<RecvMaterialListEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<RecvMaterialListEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
