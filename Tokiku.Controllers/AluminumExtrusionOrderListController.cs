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
    public class AluminumExtrusionOrderListController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<AluminumExtrusionOrderListEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<AluminumExtrusionOrderListEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<AluminumExtrusionOrderListEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<AluminumExtrusionOrderListEntity>>.CreateResultEntity(
                        new Collection<AluminumExtrusionOrderListEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<AluminumExtrusionOrderListEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
