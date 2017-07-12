using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class InventoryListController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<InventoryListEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<InventoryListEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<InventoryListEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<InventoryListEntity>>.CreateResultEntity(
                        new Collection<InventoryListEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<InventoryListEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
