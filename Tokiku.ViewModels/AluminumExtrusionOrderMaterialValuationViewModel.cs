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
    public class AluminumExtrusionOrderMaterialValuationViewModelCollection :BaseViewModelCollection<AluminumExtrusionOrderMaterialValuationViewModel>
    {
        public AluminumExtrusionOrderMaterialValuationViewModelCollection()
        {
            HasError = false;
        }

        public AluminumExtrusionOrderMaterialValuationViewModelCollection(IEnumerable<AluminumExtrusionOrderMaterialValuationViewModel> source) : base(source)
        {
            
        }

        public override void Query()
        {
            AluminumExtrusionOrderMaterialValuationController ctrl = new AluminumExtrusionOrderMaterialValuationController();
            ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>> ere = ctrl.QuerAll();
            if (!ere.HasError)
            {
                AluminumExtrusionOrderMaterialValuationViewModel vm = new AluminumExtrusionOrderMaterialValuationViewModel();
                foreach (var item in ere.Result)
                {
                    vm.SetModel(item);
                    Add(vm);
                }
            }
        }


    }

    public class AluminumExtrusionOrderMaterialValuationViewModel : BaseViewModel
    {
        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is AluminumExtrusionOrderMaterialValuationEntity)
                {
                    AluminumExtrusionOrderMaterialValuationEntity data = (AluminumExtrusionOrderMaterialValuationEntity)entity;
                    BindingFromModel(data, this);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
                throw;
            }
        }

        //"材質"
        public string Material
        {
            get { return (string)GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Material.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialProperty =
            DependencyProperty.Register("Material", typeof(string), typeof(AluminumExtrusionOrderMaterialValuationViewModel), new PropertyMetadata(string.Empty));


        //"*kg單價*"
        public Nullable<int> UnitPrice
        {
            get { return (Nullable<int>)GetValue(UnitPriceProperty); }
            set { SetValue(UnitPriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnitPrice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitPriceProperty =
            DependencyProperty.Register("UnitPrice", typeof(Nullable<int>), typeof(AluminumExtrusionOrderMaterialValuationViewModel), new PropertyMetadata(default(Nullable<int>)));


        //"重量"
        public Nullable<float> Weight
        {
            get { return (Nullable<float>)GetValue(WeightProperty); }
            set { SetValue(WeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Weight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.Register("Weight", typeof(Nullable<float>), typeof(AluminumExtrusionOrderMaterialValuationViewModel), new PropertyMetadata(default(Nullable<float>)));


        //"預估總價"
        public Nullable<int> TotalPrice
        {
            get { return (Nullable<int>)GetValue(TotalPriceProperty); }
            set { SetValue(TotalPriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalPrice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalPriceProperty =
            DependencyProperty.Register("TotalPrice", typeof(Nullable<int>), typeof(AluminumExtrusionOrderMaterialValuationViewModel), new PropertyMetadata(default(Nullable<int>)));


    }
}
