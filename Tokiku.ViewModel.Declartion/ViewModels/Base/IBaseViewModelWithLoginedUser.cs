using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tokiku.ViewModels
{
    public interface IBaseViewModelWithLoginedUser : IBaseViewModel
    {
        /// <summary>
        /// 查詢命令
        /// </summary>
        ICommand QueryCommand { get; set; }
        /// <summary>
        /// 儲存命令
        /// </summary>
        ICommand SaveCommand { get; set; }
        /// <summary>
        /// 新建命令
        /// </summary>
        ICommand CreateNewCommand { get; set; }
        /// <summary>
        /// 刪除命令
        /// </summary>
        ICommand DeleteCommand { get; set; }
        /// <summary>
        /// 處理轉送路由資料的命令
        /// </summary>
        ICommand RelayCommand { get; set; }

        /// <summary>
        /// 取得或設定對應的資料實體
        /// </summary>
        Type EntityType { get; set; }

        /// <summary>
        /// 取得目前登入的使用者
        /// </summary>
        IUserViewModel LoginedUser { get; set; }
    }
}
