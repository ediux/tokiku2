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
    public class AluminumExtrusionOrderMaterialValuationViewModelCollection : BaseViewModelCollection<AluminumExtrusionOrderMaterialValuationViewModel>
    {
        public AluminumExtrusionOrderMaterialValuationViewModelCollection()
        {
            HasError = false;
        }

        public AluminumExtrusionOrderMaterialValuationViewModelCollection(IEnumerable<AluminumExtrusionOrderMaterialValuationViewModel> source) : base(source)
        {

        }

        public static AluminumExtrusionOrderMaterialValuationViewModelCollection Query(Guid ProjectId, Guid FormDetailId)
        {
            AluminumExtrusionOrderMaterialValuationViewModelCollection returnSet = null;
            try
            {
                AluminumExtrusionOrderMaterialValuationController ctrl = new AluminumExtrusionOrderMaterialValuationController();

                ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>> ere = ctrl.Query(ProjectId, FormDetailId);

                if (!ere.HasError)
                {
                    returnSet = new AluminumExtrusionOrderMaterialValuationViewModelCollection(ere.Result.ToList()
                        .ConvertAll(c => new AluminumExtrusionOrderMaterialValuationViewModel()
                        {

                        }));
                }

                return new AluminumExtrusionOrderMaterialValuationViewModelCollection();
            }
            catch (Exception ex)
            {
                if (returnSet == null)
                    returnSet = new AluminumExtrusionOrderMaterialValuationViewModelCollection();

                returnSet.Errors = new string[] { ex.Message };
                returnSet.HasError = true;

                return returnSet;
            }
        }

        public static AluminumExtrusionOrderMaterialValuationViewModelCollection Query(Guid ProjectId)
        {
            return Query<AluminumExtrusionOrderMaterialValuationViewModelCollection, Entity.OrderMaterialValuation>("Orders", "QueryAll", ProjectId);

            //AluminumExtrusionOrderMaterialValuationController ctrl = new AluminumExtrusionOrderMaterialValuationController();
            //ExecuteResultEntity<ICollection<AluminumExtrusionOrderMaterialValuationEntity>> ere = ctrl.QuerAll();
            //if (!ere.HasError)
            //{
            //    AluminumExtrusionOrderMaterialValuationViewModel vm = new AluminumExtrusionOrderMaterialValuationViewModel();
            //    foreach (var item in ere.Result)
            //    {
            //        vm.SetModel(item);
            //        Add(vm);
            //    }
            //}
        }


    }

    public class AluminumExtrusionOrderMaterialValuationViewModel : BaseViewModelWithPOCOClass<OrderMaterialValuation>
    {
        public AluminumExtrusionOrderMaterialValuationViewModel()
        {

        }
        public AluminumExtrusionOrderMaterialValuationViewModel(OrderMaterialValuation entity) : base(entity)
        {

        }

        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        if (entity is AluminumExtrusionOrderMaterialValuationEntity)
        //        {
        //            AluminumExtrusionOrderMaterialValuationEntity data = (AluminumExtrusionOrderMaterialValuationEntity)entity;
        //            BindingFromModel(data, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //        throw;
        //    }
        //}

        //"材質"
        public string Material
        {
            get { return CopyofPOCOInstance.RequiredDetails.Materials.Name; }
            set { RaisePropertyChanged("Material"); }
        }

        

        //"*kg單價*"
        public float UnitPrice
        {
            get { return CopyofPOCOInstance.RequiredDetails.Materials.UnitPrice; }
            set { RaisePropertyChanged("UnitPrice"); }
        }

       
        //"重量"
        public double Weight
        {
            get { return CopyofPOCOInstance.Weight; }
            set { CopyofPOCOInstance.Weight = value; RaisePropertyChanged("Weight"); }
        }

      

        //"預估總價"
        public int TotalPrice
        {
            get { return CopyofPOCOInstance.TotalPrice; }
            set { CopyofPOCOInstance.TotalPrice = value; RaisePropertyChanged("TotalPrice"); }
        }

    

    }
}
