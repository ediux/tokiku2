using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ControlTableController : BaseController<ControlTableDetails>
    {
        private ExecuteResultEntity<ICollection<ControlTableDetails>> rtn;

        public ExecuteResultEntity<ICollection<ControlTableDetails>> Query(Guid ProjectId)
        {
            try
            {
                var repo = this.GetReoisitory().All();
                var result = from q in repo
                             where q.RequiredDetails.Required.ProjectId == ProjectId
                             select q;

                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(result.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
            }
        }
        public ExecuteResultEntity<ICollection<ControlTableDetails>> QueryAll(Guid ProjectId)
        {
            try
            {
                var requiresrepo = this.GetReoisitory<RequiredDetails>().All();
                var repomaster = this.GetReoisitory<ControlTables>();
                var repo = this.GetReoisitory();

                //先確認是否有管控表
                var isexistsct = from q in repo.All()
                                 where q.RequiredDetails.Required.ProjectId == ProjectId
                                 select q.ControlTables;

                ControlTables master = isexistsct.FirstOrDefault();

                if (isexistsct.Count() == 0)
                {
                    //新增管控表(主表)
                    master = new ControlTables();
                    master.Id = Guid.NewGuid();
                    master.RequiredQuantityWeightSummary = 0;
                    master.CreateTime = DateTime.Now;
                    master.CreateUserId = GetCurrentLoginUser().Result.UserId;

                    repomaster.Add(master);
                    repomaster.UnitOfWork.Commit();

                    master = repomaster.Reload(master);
                }


                //先找需求單是否存在
                var result = (from q in requiresrepo
                              where q.Required.ProjectId == ProjectId
                              select q);

                if (result.Count() > 0)
                {

                }

                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(repo.All().ToList()));
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

        public ExecuteResultEntity<ICollection<ControlTableDetails>> QuerAll()
        {
            try
            {
                var repo = this.GetReoisitory();
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(repo.All().ToList()));
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

    }
}
