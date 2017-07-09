using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class BOMViewModel : BaseViewModelWithPOCOClass<BOM>
    {
        public BOMViewModel()
        {

        }

        public BOMViewModel(BOM entity) : base(entity)
        {

        }

        #region Id
        public Guid Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }

        #endregion

        #region 加工圖集

        /// <summary>
        /// 加工圖集
        /// </summary>
        [Display(Name = "圖集", Order = 0)]
        public string ProcessingAtlas
        {
            get { return CopyofPOCOInstance.ProcessingAtlas.Name; }
            set
            {
                CopyofPOCOInstance.ProcessingAtlas.Name = value;
                RaisePropertyChanged("ProcessingAtlas");
            }
        }

        #endregion

        #region 名稱

        /// <summary>
        /// 名稱
        /// </summary>
        [Display(Name = "名稱", Order = 1)]
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set
            {
                CopyofPOCOInstance.Name = value;
                RaisePropertyChanged("Name");
            }
        }



        #endregion

        #region Combination Number

        /// <summary>
        /// 組合編號
        /// </summary>
        [Display(Name = "組合編號", Order = 2)]
        public string CombinationNumber
        {
            get { return CopyofPOCOInstance.CombinationNumber; }
            set
            {
                CopyofPOCOInstance.CombinationNumber = value;
                RaisePropertyChanged("CombinationNumber");
            }
        }



        #endregion

        #region Material Categories 材料類別

        /// <summary>
        /// 材料類別(名稱)
        /// </summary>
        [Display(Name = "材料屬性", Order = 5)]
        public string MaterialCategories
        {
            get { return CopyofPOCOInstance.MaterialCategories.Name; }
            set
            {
                try
                {
                    Controllers.MaterialManagementController controller = new Controllers.MaterialManagementController();
                    var executeresult = controller.FindMaterialCategoriesByName(value);

                    if (!executeresult.HasError)
                    {
                        CopyofPOCOInstance.MaterialCategoriesId = executeresult.Result.Single().Id;
                    }
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }
            }
        }

        #endregion

        #region Processing Number 加工編號

        /// <summary>
        /// 加工編號
        /// </summary>
        [Display(Name = "加工編號", Order = 6)]
        public string ProcessingNumber
        {
            get { return CopyofPOCOInstance.ProcessingNumber; }
            set { CopyofPOCOInstance.ProcessingNumber = value; RaisePropertyChanged("ProcessingNumber"); }
        }


        #endregion

        #region Crowded Number 擠型編號

        /// <summary>
        /// 擠型編號
        /// </summary>
        [Display(Name = "擠型編號", Order = 7)]
        public string CrowdedNumber
        {
            get { return CopyofPOCOInstance.CrowdedNumber; }
            set { CopyofPOCOInstance.CrowdedNumber = value; RaisePropertyChanged("CrowdedNumber"); }
        }



        #endregion

        #region Material Description 材料說明

        /// <summary>
        /// 材料說明
        /// </summary>
        [Display(Name = "材料說明", Order = 8)]
        public string MaterialDescription
        {
            get { return CopyofPOCOInstance.MaterialDescription; }
            set
            {
                CopyofPOCOInstance.MaterialDescription = value;
                RaisePropertyChanged("MaterialDescription");
            }
        }

        #endregion

        #region Cut Length 裁切長度

        /// <summary>
        /// 裁切長度
        /// </summary>
        [Display(Name = "裁切長度", Order = 9)]
        public string CutLength
        {
            get { return CopyofPOCOInstance.CutLength; }
            set { CopyofPOCOInstance.CutLength = value;
                RaisePropertyChanged("CutLength");
            }
        }

      

        #endregion

        #region Single Number 單樘數量

        /// <summary>
        /// 擠型編號
        /// </summary>
        [Display(Name = "單樘數量", Order = 10)]
        public decimal? SingleNumber
        {
            get { return CopyofPOCOInstance.SingleNumber; }
            set { SingleNumber = value; RaisePropertyChanged("SingleNumber"); }
        }

        #endregion

        #region TotalDemand 總需求量

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "總需求量", Order = 11)]
        public decimal TotalDemand
        {
            get { return CopyofPOCOInstance.TotalDemand; }
            set { CopyofPOCOInstance.TotalDemand = value; RaisePropertyChanged("TotalDemand"); }
        }

     


        #endregion

        #region 備註

        [Display(Name = "備註", Order = 12)]
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment; }
            set { CopyofPOCOInstance.Comment = value;
                RaisePropertyChanged("Comment");
            }
        }

       

        #endregion

        #region 位置

        [Display(Name = "位置", Order = 13)]
        public string Postion
        {
            get { return CopyofPOCOInstance.Postion; }
            set { CopyofPOCOInstance.Postion = value;
                RaisePropertyChanged("Postion");
            }
        }

       

        #endregion

        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is BOM)
                {
                    BOM data = (BOM)entity;
                    BindingFromModel(data);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
