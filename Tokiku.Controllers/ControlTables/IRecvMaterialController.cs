using System;
using System.Collections.Generic;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IRecvMaterialController : IBaseController<Receive>
    {
        IExecuteResultEntity<ICollection<Receive>> QuerAll();
        IExecuteResultEntity<ICollection<ReceiveDetails>> Query(Guid ProjectId, Guid Id);
        IExecuteResultEntity<Receive> QuerySingle(Guid ProjectId, Guid Id);
    }
}