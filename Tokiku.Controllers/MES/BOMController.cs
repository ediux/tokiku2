using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class BOMController : BaseController
    {
        public ExecuteResultEntity<Guid> GetProcessingAtlasId(string ProcessingAtlas)
        {
            try
            {
                ProcessingAtlasRepository repo = RepositoryHelper.GetProcessingAtlasRepository();
                database = repo.UnitOfWork;
                var result = repo.Where(w => w.Name == ProcessingAtlas);

                if (result.Any())
                {
                    return ExecuteResultEntity<Guid>.CreateResultEntity(result.Single().Id);
                }

                return ExecuteResultEntity<Guid>.CreateResultEntity(Guid.Empty);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Guid>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity Imports(ICollection<BOM> source)
        {
            try
            {
                if (source == null)
                    return ExecuteResultEntity.CreateErrorResultEntity(new ArgumentNullException("source"));

                BOMRepository Repo = RepositoryHelper.GetBOMRepository();
                database = Repo.UnitOfWork;

                Repo.BatchAdd(source);

                Repo.UnitOfWork.Commit();

                return ExecuteResultEntity.CreateResultEntity();
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity.CreateErrorResultEntity(ex);
            }
        }
    }
}
