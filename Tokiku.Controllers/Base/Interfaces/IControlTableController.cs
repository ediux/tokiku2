using System;
using System.Collections.Generic;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IControlTableController : IBaseController<View_RequiredControlTable>
    {
        IExecuteResultEntity<ICollection<View_RequiredControlTable>> Query(Guid ProjectId);
        IExecuteResultEntity<ICollection<View_RequiredControlTable>> QueryAll();
        IExecuteResultEntity<ICollection<View_RequiredControlTable>> QueryAll(Guid ProjectId);
        IExecuteResultEntity<ICollection<View_RequiredControlTable>> SearchByText(string text);
    }
}