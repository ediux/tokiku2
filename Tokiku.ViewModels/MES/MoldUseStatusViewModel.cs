using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MoldUseStatusViewModel : BaseViewModelWithPOCOClass<MoldUseStatus>
    {
        #region Id

        /// <summary>
        /// 模具使用狀況編號        
        /// </summary>
        public int Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }
        
        #endregion

        #region Name


        /// <summary>
        /// 使用狀況名稱
        /// </summary>
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }

        
        #endregion

        #region CreateTime


        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime
        {
            get { return CopyofPOCOInstance.CreateTime; }
            set { CopyofPOCOInstance.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }

        #endregion

        #region CreateUserId


        /// <summary>
        /// 建立人員ID
        /// </summary>
        public Guid CreateUserId
        {
            get { return CopyofPOCOInstance.CreateUserId; }
            set { CopyofPOCOInstance.CreateUserId = value; RaisePropertyChanged("CreateUserId"); }
        }

   

        #endregion

        #region CreateUser
        /// <summary>
        /// 建立的使用者
        /// </summary>
        public UserViewModel CreateUser
        {
            get { UserViewModel usermodel = new UserViewModel(); usermodel.SetModel(SystemController.GetUserById(CopyofPOCOInstance.CreateUserId).Result); return usermodel; }
            set {
                CopyofPOCOInstance.CreateUserId = value.UserId;
                RaisePropertyChanged("CreateUser");
            }
        }

        #endregion

        public async void QueryByName(string name)
        {
            try
            {

                MoldsController controller = new MoldsController();
                ExecuteResultEntity<ICollection<MoldUseStatus>> executrresult = await controller.QueryAsync(p => p.Name == name);

                if (!executrresult.HasError)
                {
                    if (executrresult.Result.Any())
                    {
                        var data = executrresult.Result.Single();
                        CopyofPOCOInstance = data;
                        CreateUser = new UserViewModel() {
                             
                        };
                        CreateUser.SetModel(controller.GetCurrentLoginUser().Result);
                        //BindingFromModel(, CreateUser);
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        public override void SetModel(dynamic entity)
        {
            try
            {
                MoldUseStatus data = (MoldUseStatus)entity;
                BindingFromModel(data);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
