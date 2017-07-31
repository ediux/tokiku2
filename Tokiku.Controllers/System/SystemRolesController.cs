using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class SystemRolesController : BaseController<Roles>
    {
        private string sql;

        public ExecuteResultEntity<ICollection<SystemRolesEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<SystemRolesEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<SystemRolesEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<SystemRolesEntity>>.CreateResultEntity(
                        new Collection<SystemRolesEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<SystemRolesEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
