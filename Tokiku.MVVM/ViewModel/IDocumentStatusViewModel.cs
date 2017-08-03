namespace Tokiku.ViewModels
{
    public interface IDocumentStatusViewModel
    {
        /// <summary>
        /// 指出是否為修改中?
        /// </summary>
        bool IsModify { get; set; }
        /// <summary>
        /// 指出是否為新建個執行個體
        /// </summary>
        bool IsNewInstance { get; set; }
        /// <summary>
        /// 指出是否為已儲存?
        /// </summary>
        bool IsSaved { get; set; }
    }
}