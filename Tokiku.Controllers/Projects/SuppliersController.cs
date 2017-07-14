using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class SuppliersController : BaseController<SupplierTranscationItem>
    {
        public ExecuteResultEntity<ICollection<SupplierTranscationItem>> QueryByProject(Guid ProjectId)
        {
            return Query(p => p.ProjectId == ProjectId);
        }

        public override ExecuteResultEntity<SupplierTranscationItem> Update(SupplierTranscationItem fromModel, bool isLastRecord = true)
        {
            try
            {

                var repo = RepositoryHelper.GetSupplierTranscationItemRepository();
                database = repo.UnitOfWork;

                var original = (from q in repo.All()
                                where q.ProjectId == fromModel.ProjectId
                                && q.ManufacturersBussinessItemsId == fromModel.ManufacturersBussinessItemsId
                                select q).Single();

                if (original != null)
                {
                    CheckAndUpdateValue(fromModel, original);
                   
                    if (isLastRecord)
                    {
                        repo.UnitOfWork.Commit();
                    }  
                }

                fromModel = repo.Get(original.ProjectId,original.ManufacturersBussinessItemsId);

                return ExecuteResultEntity<SupplierTranscationItem>.CreateResultEntity(fromModel);

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<SupplierTranscationItem>.CreateErrorResultEntity(ex);
            }
        }
    }
}
