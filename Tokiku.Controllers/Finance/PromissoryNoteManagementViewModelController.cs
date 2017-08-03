using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;

namespace Tokiku.Controllers
{
    public class PromissoryNoteManagementViewModelController : BaseController<IPromissoryNoteManagementRepository,PromissoryNoteManagement>
    {
        public ExecuteResultEntity<ICollection<PromissoryNoteManagement>> QueryAll()
        {
            try {
                var repo = this.GetRepository();
                return ExecuteResultEntity<ICollection<PromissoryNoteManagement>>.CreateResultEntity(
                    new Collection<PromissoryNoteManagement>(repo.All().ToList()));
            }catch (Exception ex) {
                return ExecuteResultEntity<ICollection<PromissoryNoteManagement>>.CreateErrorResultEntity(ex);
            }
        }

    }
}
