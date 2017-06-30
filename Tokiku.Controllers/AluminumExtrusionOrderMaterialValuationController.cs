using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class AluminumExtrusionOrderMaterialValuationController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>> QuerAll()
        {
            sql = "";

            ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<AluminumExtrusionOrderMaterialValuationEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>>.CreateResultEntity(
                        new Collection<AluminumExtrusionOrderMaterialValuationEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
