using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class ProjectContractController : BaseController<ProjectContractViewModel,ProjectContract>
    {
        public override ProjectContractViewModel CreateNew()
        {
            return new ProjectContractViewModel() { Id = Guid.NewGuid() };
        }

        public ProjectContractViewModelCollection QueryAll(Guid ProjectId)
        {
            return new ProjectContractViewModelCollection();
        }
    }
}
