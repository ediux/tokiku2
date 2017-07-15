using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    /// <summary>
    /// 材料(質)資料管理控制器
    /// </summary>
    public class MaterialManagementController : BaseController<Materials>
    {
        /// <summary>
        /// 取得查詢結果。        
        /// </summary>
        /// <param name="filiter">LINQ查詢表示式</param>
        /// <returns>傳回帶有訊息的查詢集合。</returns>
        public virtual Task<ExecuteResultEntity<ICollection<Materials>>> QueryAsync(Expression<Func<Materials, bool>> filiter)
        {
            return Task.FromResult(Query(filiter));
        }

        public ExecuteResultEntity<ICollection<MaterialCategories>> FindMaterialCategoriesByName(string Name)
        {
            try
            {
                var repo = this.GetReoisitory<MaterialCategories>();
             
                var result = from q in repo.All()
                             where q.Name.Contains(Name)
                             select q;

                return ExecuteResultEntity<ICollection<MaterialCategories>>.CreateResultEntity(new Collection<MaterialCategories>(result.ToList()));

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<MaterialCategories>>.CreateErrorResultEntity(ex);
            }
        }
    }
}
