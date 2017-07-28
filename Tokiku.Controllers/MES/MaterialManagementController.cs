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
        public ExecuteResultEntity<Materials> QueryByName(string Name)
        {
            try
            {

                var repo = this.GetRepository();
                var result = (from q in repo.All()
                              where q.Name == Name
                              select q).SingleOrDefault();

                if (result != null)
                    return ExecuteResultEntity<Materials>.CreateResultEntity(result);
                else
                {
                    Materials newMaterials = new Materials();
                    newMaterials = new Materials();
                    newMaterials.Id = Guid.NewGuid();              
                    newMaterials.ManufacturersId = Guid.Empty;
                    newMaterials.Name = Name;
                    newMaterials.UnitPrice = 0;
                    newMaterials.CreateTime = DateTime.Now;
                    newMaterials.CreateUserId = GetCurrentLoginUser().Result.UserId;

                    repo.Add(newMaterials);
                    repo.UnitOfWork.Commit();
                    return ExecuteResultEntity<Materials>.CreateResultEntity(repo.Reload(newMaterials));
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Materials>.CreateErrorResultEntity(ex);
            }
        }
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
                var repo = this.GetRepository<MaterialCategories>();

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
