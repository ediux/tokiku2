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
    public class AluminumExtrusionOrderMiscellaneousViewModelCollection : BaseViewModelCollection<AluminumExtrusionOrderMiscellaneousViewModel>
    {
        public AluminumExtrusionOrderMiscellaneousViewModelCollection()
        {
            HasError = false;
        }

        public AluminumExtrusionOrderMiscellaneousViewModelCollection(IEnumerable<AluminumExtrusionOrderMiscellaneousViewModel> source) : base(source)
        {

        }

        //public override void Query()
        //{
        //    AluminumExtrusionOrderMiscellaneousController ctrl = new AluminumExtrusionOrderMiscellaneousController();
        //    ExecuteResultEntity<ICollection<AluminumExtrusionOrderMiscellaneousEntity>> ere = ctrl.QuerAll();
        //    if (!ere.HasError)
        //    {
        //        AluminumExtrusionOrderMiscellaneousViewModel vm = new AluminumExtrusionOrderMiscellaneousViewModel();
        //        foreach (var item in ere.Result)
        //        {
        //            vm.SetModel(item);
        //            Add(vm);
        //        }
        //    }
        //}

    }
    public class AluminumExtrusionOrderMiscellaneousViewModel : BaseViewModelWithPOCOClass<AluminumExtrusionOrderMiscellaneousEntity>
    {
        public AluminumExtrusionOrderMiscellaneousViewModel()
        {

        }

        public AluminumExtrusionOrderMiscellaneousViewModel(AluminumExtrusionOrderMiscellaneousEntity entity):base(entity)
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
            get { return CopyofPOCOInstance.TokikuId; }
            set { CopyofPOCOInstance.TokikuId = value; RaisePropertyChanged("TokikuId"); }
        }

        // Using a DependencyProperty as the backing store for TokikuId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TokikuIdProperty =
            DependencyProperty.Register("TokikuId", typeof(string), typeof(AluminumExtrusionOrderMiscellaneousViewModel), new PropertyMetadata(string.Empty));


        // "*廠商編號*"
        public string ManufacturersId
        {
            get { return (string)GetValue(ManufacturersIdProperty); }
            set { SetValue(ManufacturersIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ManufacturersId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersIdProperty =
            DependencyProperty.Register("ManufacturersId", typeof(string), typeof(AluminumExtrusionOrderMiscellaneousViewModel), new PropertyMetadata(string.Empty));


        //"*說明*"
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(AluminumExtrusionOrderMiscellaneousViewModel), new PropertyMetadata(string.Empty));


        //"*單價*"
        public Nullable<int> UnitPrice
        {
            get { return (Nullable<int>)GetValue(UnitPriceProperty); }
            set { SetValue(UnitPriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnitPrice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitPriceProperty =
            DependencyProperty.Register("UnitPrice", typeof(Nullable<int>), typeof(AluminumExtrusionOrderMiscellaneousViewModel), new PropertyMetadata(default(Nullable<int>)));


        //"*數量*"
        public Nullable<int> Quantity
        {
            get { return (Nullable<int>)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Quantity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QuantityProperty =
            DependencyProperty.Register("Quantity", typeof(Nullable<int>), typeof(AluminumExtrusionOrderMiscellaneousViewModel), new PropertyMetadata(default(Nullable<int>)));


        //"*金額*"
        public Nullable<int> Amount
        {
            get { return (Nullable<int>)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Amount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register("Amount", typeof(Nullable<int>), typeof(AluminumExtrusionOrderMiscellaneousViewModel), new PropertyMetadata(default(Nullable<int>)));


    }
}
