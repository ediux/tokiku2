using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class RequiredListController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<RequiredListEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<RequiredListEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<RequiredListEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<RequiredListEntity>>.CreateResultEntity(
                        new Collection<RequiredListEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<RequiredListEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
