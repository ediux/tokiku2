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
        public ExecuteResultEntity<ICollection<ControlTableDetails>> Query(Guid ProjectId)
        {
            try
            {
                var repo = this.GetReoisitory().All();
                var result = (from q in repo
                             where q.ControlTables.ProjectId == ProjectId
                             select q).ToList();
                int i = 1;
                result.ForEach((x) => { x.RowIndex = i; i++; });
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(result));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<ControlTableDetails>> SearchByText(string text)
        {
            try
            {
                if (text != null && text.Length > 0)
                {
                    //ExecuteResultEntity<ICollection<ControlTableDetails>> model = ExecuteResultEntity<ICollection<ControlTableDetails>>
                    //     .CreateResultEntity(new Collection<ControlTableDetails>(result.ToList()));

                    //return model;
                    var result = QueryAll();
                    int i = 1;
                    result.Result.ToList().ForEach((x) => { x.RowIndex = i; i++; });
                    return result;
                }
                else
                {
                    var result = QueryAll();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<ControlTableDetails>> QueryAll()
        {
            try
            {
                var repo = this.GetReoisitory();
                var result = repo.All().ToList();
                int i = 1;
                result.ForEach((x) => { x.RowIndex = i; i++; });
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(result));
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
                if (ProjectId == Guid.Empty)
                {
                    return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                   new Collection<ControlTableDetails>());
                }

                var repo = this.GetReoisitory();

                var result = (from q in repo.All()
                             where q.ControlTables.ProjectId == ProjectId
                             select q).ToList();
                int i = 1;
                result.ForEach((x) => { x.RowIndex = i; i++; });


                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(result));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
            }
        }

        //重新計算改用資料庫內觸發程序

    }
}
