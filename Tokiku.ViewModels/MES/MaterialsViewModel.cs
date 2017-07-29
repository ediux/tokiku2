using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MaterialsViewModelCollection : BaseViewModelCollection<MaterialsViewModel, Materials>
    {
        public MaterialsViewModelCollection()
        {

        }

        public MaterialsViewModelCollection(IEnumerable<MaterialsViewModel> source) : base(source)
        {

        }
    }

    public class MaterialsViewModel : BaseViewModelWithPOCOClass<Materials>
    {
        public MaterialsViewModel()
        {

        }

        public MaterialsViewModel(Materials entity) : base(entity)
        {

        }


        #region Name

        /// <summary>
        /// 材料(材質)名稱
        /// </summary>
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; }
        }


        #endregion

        #region ManufacturersId

        /// <summary>
        /// 廠商編號
        /// </summary>
        public Guid ManufacturersId
        {
            get { return CopyofPOCOInstance.ManufacturersId; }
            set { CopyofPOCOInstance.ManufacturersId = value; RaisePropertyChanged("ManufacturersId"); }
        }



        #endregion

        #region UnitPrice

        /// <summary>
        /// 單價
        /// </summary>
        public float UnitPrice
        {
            get { return CopyofPOCOInstance.UnitPrice; }
            set { CopyofPOCOInstance.UnitPrice = value; RaisePropertyChanged("UnitPrice"); }
        }

        #endregion




        public static MaterialsViewModel QueryByName(string name)
        {
            try
            {
                return QuerySingle<MaterialsViewModel, Materials>("MaterialManagement", "QueryByName", name);
                //MaterialManagementController controller = new MaterialManagementController();
                //var executrresult = await controller.QueryAsync(p => p.Name == name);

                //if (!executrresult.HasError)
                //{
                //    if (executrresult.Result.Any())
                //    {
                //        var data = executrresult.Result.Single();
                //        //BindingFromModel(data, this);                     
                //        //CreateUser = new UserViewModel();
                //        //BindingFromModel(data.CreateUser, CreateUser);
                //    }
                //}
            }
            catch (Exception ex)
            {
                MaterialsViewModel model = new MaterialsViewModel();
                setErrortoModel(model, ex);
                return model;
            }
        }
    }
}
