using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ContractManagementController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<ContractManagementEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<ContractManagementEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<ContractManagementEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<ContractManagementEntity>>.CreateResultEntity(
                        new Collection<ContractManagementEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<ContractManagementEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
