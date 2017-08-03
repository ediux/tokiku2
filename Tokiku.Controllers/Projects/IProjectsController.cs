using System;
using System.Collections.Generic;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IProjectsController : IBaseController<Projects>
    {

        void Delete(Guid ProjectId, Guid UserId);
        IExecuteResultEntity<string> GetNextProjectSerialNumber(string year);
        IExecuteResultEntity<ICollection<States>> GetStates();
        bool IsExists(Guid ProjectId);
        IExecuteResultEntity<ICollection<ProjectListEntity>> QueryAll();
        IExecuteResultEntity<Projects> QuerySingle(Guid ProjectId);
        IExecuteResultEntity<ICollection<ProjectListEntity>> SearchByText(string text);

    }
}