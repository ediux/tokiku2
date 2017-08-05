
namespace Tokiku.ViewModels
{
    /// <summary>
    /// 文件操作生命週期
    /// </summary>
    public enum DocumentLifeCircle
    {
        None = 0,
        Create = 1,
        Read = 2,
        Update = 3,
        Delete = 4,
        Save = 5
    }
}