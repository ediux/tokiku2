using System;
using System.Collections.Generic;
using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.Controllers
{
    public interface IRecvMaterialController : IViewController
    {
        IExecuteResultEntity<ICollection<Receive>> QuerAll();
        IExecuteResultEntity<ICollection<ReceiveDetails>> Query(Guid ProjectId, Guid Id);
        IExecuteResultEntity<Receive> QuerySingle(Guid ProjectId, Guid Id);
    }
}