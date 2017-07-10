using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ShippingMaterialController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<ShippingMaterialEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<ShippingMaterialEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<ShippingMaterialEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<ShippingMaterialEntity>>.CreateResultEntity(
                        new Collection<ShippingMaterialEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<ShippingMaterialEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
