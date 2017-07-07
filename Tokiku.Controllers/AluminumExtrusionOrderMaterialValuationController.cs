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
        public ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>> Query(Guid ProjectId, Guid FormDetailId)
        {
            try
            {
                var repo = RepositoryHelper.GetMaterialValuationRepository();

                database = repo.UnitOfWork;
                var queryresult = (from q in repo.All()
                                   where q.FormDetails.ProjectId == ProjectId && q.FormDetailId == FormDetailId
                                   select new AluminumExtrusionOrderMaterialValuationEntity()
                                   {
                                       Material = q.Material,
                                       TotalPrice = q.TotalPrice,
                                       UnitPrice = q.UnitPrice,
                                       Weight = q.Weight
                                   });

                if (queryresult.Any())
                {
                    return ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>>
                        .CreateResultEntity(new Collection<AluminumExtrusionOrderMaterialValuationEntity>(queryresult.ToList()));
                }

                return ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>>.CreateResultEntity(new Collection<AluminumExtrusionOrderMaterialValuationEntity>());
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>>.CreateErrorResultEntity(ex);
            }
        }
        private string sql;

        public ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>> QuerAll()
        {
            sql = " select Material, UnitPrice, Weight, TotalPrice " +
                    " from TABL2 ";

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
