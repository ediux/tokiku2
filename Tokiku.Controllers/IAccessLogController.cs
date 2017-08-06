using Tokiku.Entity;
using Tokiku.MVVM;

namespace Tokiku.Controllers
{
    public interface IAccessLogController : IViewController
    {
        ActionResult QueryLastUpdateLog(string DataId);
    }
}