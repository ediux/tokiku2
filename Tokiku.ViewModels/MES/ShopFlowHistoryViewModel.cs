using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

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

        #region Model Command Functions

        public override void Query()
        {

        }

        public override void SaveModel()
        {

        }
        #endregion

    }


    public class ShopFlowHistoryViewModel : BaseViewModel
    {
        #region 內部變數
        private Controllers.ShopFlowController controller;
        #endregion

        #region 建構式
        public ShopFlowHistoryViewModel() : base()
        {
            controller = new Controllers.ShopFlowController();
        }
        #endregion

        #region 欄位屬性 Fields(DP)

        #region Id


        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(ShopFlowHistoryViewModel), new PropertyMetadata(Guid.NewGuid()));


        #endregion

        #region EngineeringId


        public Guid EngineeringId
        {
            get { return (Guid)GetValue(EngineeringIdProperty); }
            set { SetValue(EngineeringIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EngineeringId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EngineeringIdProperty =
            DependencyProperty.Register("EngineeringId", typeof(Guid), typeof(ShopFlowHistoryViewModel), new PropertyMetadata(Guid.Empty));

        #endregion

        #region ShopId


        public Guid? ShopId
        {
            get { return (Guid?)GetValue(ShopIdProperty); }
            set { SetValue(ShopIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShopId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShopIdProperty =
            DependencyProperty.Register("ShopId", typeof(Guid?), typeof(ShopFlowHistoryViewModel), new PropertyMetadata(default(Guid?)));

        #endregion

        #region State


        public byte State
        {
            get { return (byte)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(byte), typeof(ShopFlowHistoryViewModel), new PropertyMetadata((byte)1));


        #endregion

        #region CreateTime
        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(ShopFlowHistoryViewModel), new PropertyMetadata(DateTime.Now));

        #endregion

        #region CreateUserId

        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(ShopFlowHistoryViewModel), new PropertyMetadata(default(Guid)));

        #endregion

        #endregion

        #region Model Command Functions      

        public override void Query()
        {

        }

        public override void SaveModel()
        {

        }
        #endregion
    }
}
