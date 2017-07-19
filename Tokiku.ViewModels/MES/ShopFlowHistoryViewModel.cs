using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ShopFlowHistoryViewModelCollection : BaseViewModelCollection<ShopFlowHistoryViewModel>
    {
        #region 建構式
        public ShopFlowHistoryViewModelCollection()
        {

        }
        public ShopFlowHistoryViewModelCollection(IEnumerable<ShopFlowHistoryViewModel> source) : base(source)
        {

        }
        #endregion

      

    }


    public class ShopFlowHistoryViewModel : BaseViewModelWithPOCOClass<ShopFlowHistory>
    {
        #region 內部變數
        private Controllers.ShopFlowController controller;
        #endregion

        #region 建構式
        public ShopFlowHistoryViewModel() : base()
        {
            controller = new Controllers.ShopFlowController();
        }
        public ShopFlowHistoryViewModel(ShopFlowHistory entity):base(entity)
        {

        }
        #endregion

        #region 欄位屬性 Fields(DP)

       

      


        
      
     

        #endregion

       
    }
}
