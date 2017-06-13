using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;

namespace Tokiku.ViewModels
{
    public class MaterialsViewModelCollection : BaseViewModelCollection<MaterialsViewModel>
    {
        public MaterialsViewModelCollection()
        {

        }

        public MaterialsViewModelCollection(IEnumerable<MaterialsViewModel> source) : base(source)
        {

        }
    }

    public class MaterialsViewModel : BaseViewModel
    {
        #region Id

        /// <summary>
        /// 編號
        /// </summary>
        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(MaterialsViewModel), new PropertyMetadata(Guid.NewGuid()));


        #endregion

        #region Name

        /// <summary>
        /// 材料(材質)名稱
        /// </summary>
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(MaterialsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region ManufacturersId

        /// <summary>
        /// 廠商編號
        /// </summary>
        public Guid ManufacturersId
        {
            get { return (Guid)GetValue(ManufacturersIdProperty); }
            set { SetValue(ManufacturersIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Manufacturers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersIdProperty =
            DependencyProperty.Register("Manufacturers", typeof(Guid), typeof(MaterialsViewModel), new PropertyMetadata(Guid.Empty));


        #endregion

        #region UnitPrice

        /// <summary>
        /// 單價
        /// </summary>
        public float UnitPrice
        {
            get { return (float)GetValue(UnitPriceProperty); }
            set { SetValue(UnitPriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnitPrice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitPriceProperty =
            DependencyProperty.Register("UnitPrice", typeof(float), typeof(MaterialsViewModel), new PropertyMetadata(0F));


        #endregion

        #region CreateTime

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(MaterialsViewModel), new PropertyMetadata(DateTime.Now));


        #endregion

        #region CreateUser


        public UserViewModel CreateUser
        {
            get { return (UserViewModel)GetValue(CreateUserProperty); }
            set { SetValue(CreateUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserProperty =
            DependencyProperty.Register("CreateUser", typeof(UserViewModel), typeof(MaterialsViewModel), new PropertyMetadata(default(UserViewModel)));


        #endregion

       

        public async void QueryByName(string name)
        {
            try
            {

                MaterialManagementController controller = new MaterialManagementController();
                var executrresult = await controller.QueryAsync(p => p.Name == name);

                if (!executrresult.HasError)
                {
                    if (executrresult.Result.Any())
                    {
                        var data = executrresult.Result.Single();
                        BindingFromModel(data, this);                     
                        CreateUser = new UserViewModel();
                        BindingFromModel(data.CreateUser, CreateUser);
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
