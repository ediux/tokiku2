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
    public class PromissoryNoteManagementViewModelController : BaseController
    {
        private ExecuteResultEntity<ICollection<PromissoryNoteManagement>> rtn;

        public ExecuteResultEntity<ICollection<PromissoryNoteManagement>> QuerAll()
        {
            try {
                var repo = RepositoryHelper.GetPromissoryNoteManagementRepository();
                return ExecuteResultEntity<ICollection<PromissoryNoteManagement>>.CreateResultEntity(
                    new Collection<PromissoryNoteManagement>(repo.All().ToList()));
            }catch (Exception ex) {
                rtn = ExecuteResultEntity<ICollection<PromissoryNoteManagement>>.CreateErrorResultEntity(ex);
                return rtn;
            }

        }

    }
}
