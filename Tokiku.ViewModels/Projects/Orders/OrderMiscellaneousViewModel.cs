using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class OrderMiscellaneousViewModelCollection :  BaseViewModelCollection<OrderMiscellaneousViewModel,OrderMiscellaneous>
    {
        public OrderMiscellaneousViewModelCollection()
        {
            HasError = false;
        }

        public OrderMiscellaneousViewModelCollection(IEnumerable<OrderMiscellaneousViewModel> source) : base(source)
        {

        }

        public static OrderMiscellaneousViewModelCollection Query(Guid ProjectId)
        {
            return Query<OrderMiscellaneousViewModelCollection>("OrderMiscellaneous", "QueryAll", ProjectId);
            //AluminumExtrusionOrderMiscellaneousController ctrl = new AluminumExtrusionOrderMiscellaneousController();
            //ExecuteResultEntity<ICollection<AluminumExtrusionOrderMiscellaneousEntity>> ere = ctrl.QuerAll();
            //if (!ere.HasError)
            //{
            //    AluminumExtrusionOrderMiscellaneousViewModel vm = new AluminumExtrusionOrderMiscellaneousViewModel();
            //    foreach (var item in ere.Result)
            //    {
            //        vm.SetModel(item);
            //        Add(vm);
            //    }
            //}
        }

    }
    public class OrderMiscellaneousViewModel : BaseViewModelWithPOCOClass<OrderMiscellaneous>
    {
        public OrderMiscellaneousViewModel()
        {

        }

        public OrderMiscellaneousViewModel(OrderMiscellaneous entity):base(entity)
        {

        }
        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is AluminumExtrusionOrderMiscellaneousEntity)
        //        {
        //            AluminumExtrusionOrderMiscellaneousEntity data = (AluminumExtrusionOrderMiscellaneousEntity)entity;
        //            BindingFromModel(data, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //        throw;
        //    }
        //}

        // "*東菊編號/項目*"
        public string TokikuId
        {
            get { return CopyofPOCOInstance.CodeOrItem; }
            set { CopyofPOCOInstance.CodeOrItem = value; RaisePropertyChanged("TokikuId"); }
        }

     

        // "*廠商編號*"
        public string ManufacturersId
        {
            get { return CopyofPOCOInstance.FactoryNumber; }
            set { CopyofPOCOInstance.FactoryNumber = value;RaisePropertyChanged("ManufacturersId"); }
        }

        //"*說明*"
        public string Description
        {
            get { return CopyofPOCOInstance.Description; }
            set { CopyofPOCOInstance.Description = value;RaisePropertyChanged("Description"); }
        }

       

        //"*單價*"
        public int UnitPrice
        {
            get { return CopyofPOCOInstance.UnitPrice; }
            set { CopyofPOCOInstance.UnitPrice = value; RaisePropertyChanged("UnitPrice"); }
        }

      
        //"*數量*"
        public int Quantity
        {
            get { return CopyofPOCOInstance.Quantity; }
            set { CopyofPOCOInstance.Quantity = value; RaisePropertyChanged("Quantity"); }
        }

      

        //"*金額*"
        public decimal Amount
        {
            get { return CopyofPOCOInstance.TotalPrice; }
            set { var total = UnitPrice * Quantity;

                if (value != total)
                {
                    CopyofPOCOInstance.TotalPrice = total;
                }

                RaisePropertyChanged("Amount"); }
        }

     
    }
}
