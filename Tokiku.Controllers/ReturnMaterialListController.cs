using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ReturnMaterialListController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<ReturnMaterialListEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<ReturnMaterialListEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<ReturnMaterialListEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<ReturnMaterialListEntity>>.CreateResultEntity(
                        new Collection<ReturnMaterialListEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<ReturnMaterialListEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
