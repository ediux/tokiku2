using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class AluminumExtrusionOrderMiscellaneousController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<AluminumExtrusionOrderMiscellaneousEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Description, UnitPrice, " +
                         " Quantity, UnitPrice*Quantity as Total " +
                    " from TABL3 a " +
               " left join TABL1 b on b.Id = a.TABL1ID ";

            ExecuteResultEntity<ICollection<AluminumExtrusionOrderMiscellaneousEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<AluminumExtrusionOrderMiscellaneousEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<AluminumExtrusionOrderMiscellaneousEntity>>.CreateResultEntity(
                        new Collection<AluminumExtrusionOrderMiscellaneousEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<AluminumExtrusionOrderMiscellaneousEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
