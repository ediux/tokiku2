using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;

namespace Tokiku.ViewModels
{
    public class MoldsViewModel : BaseViewModelWithPOCOClass<MoldsInProjects>
    {
        public MoldsViewModel() : base()
        {

        }

        public MoldsViewModel(MoldsInProjects entity) : base(entity)
        {

        }

        #region Id
        /// <summary>
        /// 編號
        /// </summary>
        public Guid Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }

        #endregion

        #region Open Date
        /// <summary>
        /// 開模日期
        /// </summary>
        public DateTime? OpenDate
        {
            get { return CopyofPOCOInstance.Molds.OpenDate; }
            set { CopyofPOCOInstance.Molds.OpenDate = value; RaisePropertyChanged("OpenDate"); }
        }

        #endregion

        #region LegendMoldReduction

        /// <summary>
        /// 圖例
        /// </summary>
        public string LegendMoldReduction
        {
            get { return CopyofPOCOInstance.Molds.LegendMoldReduction; }
            set { CopyofPOCOInstance.Molds.LegendMoldReduction = value; RaisePropertyChanged("LegendMoldReduction"); }
        }

        #endregion

        #region UsePosition

        /// <summary>
        /// 使用位置
        /// </summary>
        public string UsePosition
        {
            get { return CopyofPOCOInstance.Molds.UsePosition; }
            set { CopyofPOCOInstance.Molds.UsePosition = value; RaisePropertyChanged("UsePosition"); }
        }

        #endregion

        #region Code

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get { return CopyofPOCOInstance.Molds.Code; }
            set { CopyofPOCOInstance.Molds.Code = value; RaisePropertyChanged("Code"); }
        }

        #endregion

        #region ManufacturersId


        /// <summary>
        /// 廠商編號
        /// </summary>
        public string ManufacturersCode
        {
            get { return CopyofPOCOInstance.Molds.Manufacturers.Code; }
            set { CopyofPOCOInstance.Molds.Manufacturers.Code = value; RaisePropertyChanged("ManufacturersCode"); }
        }

        #endregion

        #region Manufacturers

        /// <summary>
        /// 廠商
        /// </summary>
        public string ManufacturersName
        {
            get { return CopyofPOCOInstance.Molds.Manufacturers.Name; }
            set { CopyofPOCOInstance.Molds.Manufacturers.Name = value; RaisePropertyChanged("ManufacturersName"); }
        }

        #endregion

        #region Material Name 材質

        /// <summary>
        /// 材質
        /// </summary>
        public string MaterialName
        {
            get { return CopyofPOCOInstance.Molds.Materials.Name; }
            set { CopyofPOCOInstance.Molds.Materials.Name = value; RaisePropertyChanged("ManufacturersName"); }
        }

        #endregion

        #region Unit Weight

        /// <summary>
        /// 單位重(KG/M)
        /// </summary>
        public float UnitWeight
        {
            get { return CopyofPOCOInstance.Molds.UnitWeight; }
            set { CopyofPOCOInstance.Molds.UnitWeight = value; RaisePropertyChanged("UnitWeight"); }
        }

        #endregion

        #region Surface Treatment

        /// <summary>
        /// 表面處理
        /// </summary>
        public string SurfaceTreatment
        {
            get { return CopyofPOCOInstance.Molds.SurfaceTreatment; }
            set { CopyofPOCOInstance.Molds.SurfaceTreatment = value; RaisePropertyChanged("SurfaceTreatment"); }
        }


        #endregion

        #region PaintArea

        /// <summary>
        /// 烤漆面積
        /// </summary>
        public float PaintArea
        {
            get { return CopyofPOCOInstance.Molds.PaintArea; }
            set { CopyofPOCOInstance.Molds.PaintArea = value; RaisePropertyChanged("PaintArea"); }
        }

        #endregion

        #region MembraneTreatment


        /// <summary>
        /// 皮膜處理
        /// </summary>
        public float MembraneTreatment
        {
            get { return CopyofPOCOInstance.Molds.MembraneTreatment; }
            set { CopyofPOCOInstance.Molds.MembraneTreatment = value; RaisePropertyChanged("MembraneTreatment"); }
        }



        #endregion

        #region MinimumYield

        /// <summary>
        /// 最低產量
        /// </summary>
        public float MinimumYield
        {
            get { return CopyofPOCOInstance.Molds.MinimumYield; }
            set { CopyofPOCOInstance.Molds.MinimumYield = value; RaisePropertyChanged("MinimumYield"); }
        }

        #endregion

        #region ProductionIngot


        /// <summary>
        /// 模具費用
        /// </summary>
        public float ProductionIngot
        {
            get { return CopyofPOCOInstance.Molds.ProductionIngot; }
            set { CopyofPOCOInstance.Molds.ProductionIngot = value; RaisePropertyChanged("ProductionIngot"); }
        }



        #endregion

        #region TotalOrderWeight

        /// <summary>
        /// 訂單總重量
        /// </summary>
        public float TotalOrderWeight
        {
            get { return CopyofPOCOInstance.Molds.TotalOrderWeight; }
            set { CopyofPOCOInstance.Molds.TotalOrderWeight = value; RaisePropertyChanged("TotalOrderWeight"); }
        }

        #endregion


        #region Comment

        /// <summary>
        /// 備註
        /// </summary>
        public string Comment
        {
            get { return CopyofPOCOInstance.Molds.Comment; }
            set { CopyofPOCOInstance.Molds.Comment = value; RaisePropertyChanged("Comment"); }
        }

        #endregion

        #region CreateTime


        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime
        {
            get { return CopyofPOCOInstance.Molds.CreateTime; }
            set { CopyofPOCOInstance.Molds.CreateTime = value; RaisePropertyChanged("CreateTime"); }
        }


        #endregion

        #region CreateUserId


        /// <summary>
        /// 建立人員ID
        /// </summary>
        public Guid CreateUserId
        {
            get { return CopyofPOCOInstance.Molds.CreateUserId; }
            set { CopyofPOCOInstance.Molds.CreateUserId = value; RaisePropertyChanged("CreateUserId"); }
        }



        #endregion

        #region CreateUser
        /// <summary>
        /// 建立的使用者
        /// </summary>
        public string CreateUser
        {
            get
            {
                return CopyofPOCOInstance.Molds.CreateUser.UserName;
            }
            set
            {
                SystemController sysCtrl = new SystemController();
                var executeresult = sysCtrl.GetUser(value);
                if (!executeresult.HasError)
                {
                    CopyofPOCOInstance.Molds.CreateUserId = executeresult.Result.UserId;
                }
            }
        }



        #endregion

        #region MoldUseStatus

        /// <summary>
        /// 模具使用狀況
        /// </summary>
        public string MoldUseStatus
        {
            get { return CopyofPOCOInstance.Molds.MoldUseStatus.Name; }
            set { CopyofPOCOInstance.Molds.MoldUseStatus.Name = value; RaisePropertyChanged("MoldUseStatus"); }
        }

        #endregion

        #region ProjectName


        public string ProjectName
        {
            get { return CopyofPOCOInstance.Projects.Name; }
            set { RaisePropertyChanged("ProjectName"); }
        }


        #endregion

        #region SerialNumber

        /// <summary>
        /// 大同編號
        /// </summary>
        public string SerialNumber
        {
            get { return CopyofPOCOInstance.Molds.SerialNumber; }
            set { CopyofPOCOInstance.Molds.SerialNumber = value; RaisePropertyChanged("SerialNumber"); }
        }


        #endregion

        #region Name1

        public String Name1
        {
            get { return ""; }
            set { }
        }

        #endregion

        #region Name2

        public string Name2
        {
            get { return ""; }
            set { }
        }



        #endregion

        public override void Initialized()
        {
            base.Initialized();

            Id = Guid.NewGuid();

            Controllers.MoldsController moldcontroller = new Controllers.MoldsController();
            var loginedUser = moldcontroller.GetCurrentLoginUser();

            if (!loginedUser.HasError)
            {
                CreateUserId = loginedUser.Result.UserId;
                CreateUser = loginedUser.Result.UserName;

                //CreateUser.SetModel(loginedUser.Result);
            }

        }

        //public virtual Manufacturers Manufacturers { get; set; }
        //public virtual Materials Materials { get; set; }
        //public virtual MoldUseStatus MoldUseStatus { get; set; }
        //ICollection<MoldsInProjects> ProjectMolds { get; set; }
        public override void SaveModel()
        {
            try
            {

            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
