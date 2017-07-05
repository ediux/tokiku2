using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ShippingMaterialListController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<ShippingMaterialListEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<ShippingMaterialListEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<ShippingMaterialListEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<ShippingMaterialListEntity>>.CreateResultEntity(
                        new Collection<ShippingMaterialListEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<ShippingMaterialListEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
