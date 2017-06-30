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
    public class AluminumExtrusionOrderViewModelCollection : BaseViewModelCollection<AluminumExtrusionOrderViewModel>
    {
        public AluminumExtrusionOrderViewModelCollection()
        {
            HasError = false;
        }

        public AluminumExtrusionOrderViewModelCollection(IEnumerable<AluminumExtrusionOrderViewModel> source) : base(source)
        {


        }

        public override void Query()
        {
            AluminumExtrusionOrderController ctrl = new AluminumExtrusionOrderController();
            ExecuteResultEntity<ICollection<AluminumExtrusionOrderEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                AluminumExtrusionOrderViewModel vm = new AluminumExtrusionOrderViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }

    }
    public class AluminumExtrusionOrderViewModel : BaseViewModel
    {
        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is AluminumExtrusionOrderEntity)
                {
                    AluminumExtrusionOrderEntity data = (AluminumExtrusionOrderEntity)entity;
                    BindingFromModel(data, this);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
                throw;
            }
        }

        // "*東菊編號*"
        public string TokikuId
        {
            get { return (string)GetValue(TokikuIdProperty); }
            set { SetValue(TokikuIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TokikuId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TokikuIdProperty =
            DependencyProperty.Register("TokikuId", typeof(string), typeof(AluminumExtrusionOrderViewModel), new PropertyMetadata(string.Empty));


        // "*大同編號*"
        public string ManufacturersId
        {
            get { return (string)GetValue(ManufacturersIdProperty); }
            set { SetValue(ManufacturersIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ManufacturersId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersIdProperty =
            DependencyProperty.Register("ManufacturersId", typeof(string), typeof(AluminumExtrusionOrderViewModel), new PropertyMetadata(string.Empty));


        // "*材質*"
        public string Material
        {
            get { return (string)GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Material.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialProperty =
            DependencyProperty.Register("Material", typeof(string), typeof(AluminumExtrusionOrderViewModel), new PropertyMetadata(string.Empty));


        // "*單位重(kg/m)*"
        public Nullable<float> UnitWeight
        {
            get { return (Nullable<float>)GetValue(UnitWeightProperty); }
            set { SetValue(UnitWeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnitWeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitWeightProperty =
            DependencyProperty.Register("UnitWeight", typeof(Nullable<float>), typeof(AluminumExtrusionOrderViewModel), new PropertyMetadata(default(Nullable<float>)));


        // "*訂購長度(mm)*"
        public Nullable<int> OrderLength
        {
            get { return (Nullable<int>)GetValue(OrderLengthProperty); }
            set { SetValue(OrderLengthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OrderLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderLengthProperty =
            DependencyProperty.Register("OrderLength", typeof(Nullable<int>), typeof(AluminumExtrusionOrderViewModel), new PropertyMetadata(default(Nullable<int>)));


        // "[需求數量]"
        public Nullable<int> RequiredQuantity
        {
            get { return (Nullable<int>)GetValue(RequiredQuantityProperty); }
            set { SetValue(RequiredQuantityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RequiredQuantity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RequiredQuantityProperty =
            DependencyProperty.Register("RequiredQuantity", typeof(Nullable<int>), typeof(AluminumExtrusionOrderViewModel), new PropertyMetadata(default(Nullable<int>)));


        // "[備品數量]"
        public Nullable<int> SparePartsQuantity
        {
            get { return (Nullable<int>)GetValue(SparePartsQuantityProperty); }
            set { SetValue(SparePartsQuantityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SparePartsQuantity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SparePartsQuantityProperty =
            DependencyProperty.Register("SparePartsQuantity", typeof(Nullable<int>), typeof(AluminumExtrusionOrderViewModel), new PropertyMetadata(default(Nullable<int>)));


        // "[下單數量]"
        public Nullable<int> PlaceAnOrderQuantity
        {
            get { return (Nullable<int>)GetValue(PlaceAnOrderQuantityProperty); }
            set { SetValue(PlaceAnOrderQuantityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceAnOrderQuantity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceAnOrderQuantityProperty =
            DependencyProperty.Register("PlaceAnOrderQuantity", typeof(Nullable<int>), typeof(AluminumExtrusionOrderViewModel), new PropertyMetadata(default(Nullable<int>)));


        // "[備註]"
        public string Note
        {
            get { return (string)GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Note.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register("Note", typeof(string), typeof(AluminumExtrusionOrderViewModel), new PropertyMetadata(string.Empty));


    }
}
