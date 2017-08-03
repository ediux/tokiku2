using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IAccessLogController : IBaseController<AccessLog>
    {
        IExecuteResultEntity<AccessLog> QueryLastUpdateLog(string DataId);
    }
}