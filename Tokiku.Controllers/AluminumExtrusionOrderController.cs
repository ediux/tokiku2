using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class AluminumExtrusionOrderController : BaseController
    {
        private string sql;

        public ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>> Query(Guid ProjectId, Guid FormDetilId)
        {
            try
            {
                var repo = RepositoryHelper.GetOrdersRepository();

                database = repo.UnitOfWork;
                var queryresult = (from q in repo.All()
                                   //where q.FormDetails.ProjectId == ProjectId && q.FormDetailId == FormDetilId
                                   select new AluminumExtrusionOrderEntity() { });

                if (queryresult.Any())
                {
                    return ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>>.CreateResultEntity(new Collection<AluminumExtrusionOrderEntity>(queryresult.ToList()));
                }

                return ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>>.CreateResultEntity(new Collection<AluminumExtrusionOrderEntity>());
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>>.CreateErrorResultEntity(ex);
            }
        }

     
        public ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<AluminumExtrusionOrderEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>>.CreateResultEntity(
                        new Collection<AluminumExtrusionOrderEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
