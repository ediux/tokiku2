using System;
using System.Collections.Generic;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.Controllers
{
    public interface IControlTableController : IViewController
    {
        IExecuteResultEntity<ICollection<View_RequiredControlTable>> Query(Guid ProjectId);
        IExecuteResultEntity<ICollection<View_RequiredControlTable>> QueryAll();
        IExecuteResultEntity<ICollection<View_RequiredControlTable>> QueryAll(Guid ProjectId);
        IExecuteResultEntity<ICollection<View_RequiredControlTable>> SearchByText(string text);
    }
}