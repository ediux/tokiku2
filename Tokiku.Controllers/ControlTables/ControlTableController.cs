using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ControlTableController : BaseController<View_RequiredControlTable>
    {
        public ExecuteResultEntity<ICollection<View_RequiredControlTable>> Query(Guid ProjectId)
        {
            try
            {
                var repo = this.GetRepository().All();
                var result = (from q in repo
                              where q.ProjectId == ProjectId
                              select q).ToList();
                int i = 1;
                result.ForEach((x) => { x.RowIndex = i; i++; });
                return ExecuteResultEntity<ICollection<View_RequiredControlTable>>.CreateResultEntity(
                    new Collection<View_RequiredControlTable>(result));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<View_RequiredControlTable>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<View_RequiredControlTable>> SearchByText(string text)
        {
            try
            {
                if (text != null && text.Length > 0)
                {
                    //ExecuteResultEntity<ICollection<ControlTableDetails>> model = ExecuteResultEntity<ICollection<ControlTableDetails>>
                    //     .CreateResultEntity(new Collection<ControlTableDetails>(result.ToList()));

                    //return model;
                    var result = (from q in this.GetRepository()
                                  where q.Code.Contains(text) || q.Materials.Contains(text) || q.ManufacturersName.Contains(text)
                                  select q).ToList();
                    int i = 1;
                    result.ForEach((x) => { x.RowIndex = i; i++; });
                    return  ExecuteResultEntity<ICollection<View_RequiredControlTable>>
                        .CreateResultEntity(new Collection<View_RequiredControlTable>(result));
                }
                else
                {
                    var result = QueryAll();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<View_RequiredControlTable>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<View_RequiredControlTable>> QueryAll()
        {
            try
            {
                var repo = this.GetRepository();
                var result = repo.All().ToList();
                int i = 1;
                result.ForEach((x) => { x.RowIndex = i; i++; });
                return ExecuteResultEntity<ICollection<View_RequiredControlTable>>.CreateResultEntity(
                    new Collection<View_RequiredControlTable>(result));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<View_RequiredControlTable>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<View_RequiredControlTable>> QueryAll(Guid ProjectId)
        {
            try
            {
                if (ProjectId == Guid.Empty)
                {
                    return ExecuteResultEntity<ICollection<View_RequiredControlTable>>.CreateResultEntity(
                   new Collection<View_RequiredControlTable>());
                }

                var repo = this.GetRepository();

                var result = (from q in repo.All()
                              where q.ProjectId == ProjectId
                              select q).ToList();
                int i = 1;
                result.ForEach((x) => { x.RowIndex = i; i++; });


                return ExecuteResultEntity<ICollection<View_RequiredControlTable>>.CreateResultEntity(
                    new Collection<View_RequiredControlTable>(result));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<View_RequiredControlTable>>.CreateErrorResultEntity(ex);
            }
        }

        //重新計算改用資料庫內觸發程序

      
    }
}
