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
    public class BOMViewModel : BaseViewModel
    {
        public BOMViewModel()
        {

        }


        #region Id
        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(BOMViewModel), new PropertyMetadata(Guid.NewGuid()));
        #endregion

        #region 加工圖集

        /// <summary>
        /// 加工圖集
        /// </summary>
        [Display(Name = "圖集", Order = 0)]
        public string ProcessingAtlas
        {
            get { return (string)GetValue(ProcessingAtlasProperty); }
            set { SetValue(ProcessingAtlasProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProcessingAtlas.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProcessingAtlasProperty =
            DependencyProperty.Register("ProcessingAtlas", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region 名稱

        /// <summary>
        /// 名稱
        /// </summary>
        [Display(Name = "名稱", Order = 1)]
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region Combination Number

        /// <summary>
        /// 組合編號
        /// </summary>
        [Display(Name = "組合編號", Order = 2)]
        public string CombinationNumber
        {
            get { return (string)GetValue(CombinationNumberProperty); }
            set { SetValue(CombinationNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CombinationNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CombinationNumberProperty =
            DependencyProperty.Register("CombinationNumber", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region MaterialCategoriesId

        /// <summary>
        /// 材料類別
        /// </summary>
        public Guid MaterialCategoriesId
        {
            get { return (Guid)GetValue(MaterialCategoriesIdProperty); }
            set { SetValue(MaterialCategoriesIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaterialCategoriesId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialCategoriesIdProperty =
            DependencyProperty.Register("MaterialCategoriesId", typeof(Guid), typeof(BOMViewModel), new PropertyMetadata(Guid.Empty));


        #endregion

        #region Material Categories 材料類別

        /// <summary>
        /// 材料類別(名稱)
        /// </summary>
        [Display(Name = "材料屬性", Order = 5)]
        public string MaterialCategories
        {
            get { return (string)GetValue(MaterialCategoriesProperty); }
            set { SetValue(MaterialCategoriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaterialCategories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialCategoriesProperty =
            DependencyProperty.Register("MaterialCategories", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region Processing Number 加工編號

        /// <summary>
        /// 加工編號
        /// </summary>
        [Display(Name = "加工編號", Order = 6)]
        public string ProcessingNumber
        {
            get { return (string)GetValue(ProcessingNumberProperty); }
            set { SetValue(ProcessingNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProcessingNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProcessingNumberProperty =
            DependencyProperty.Register("ProcessingNumber", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));

        #endregion

        #region Crowded Number 擠型編號

        /// <summary>
        /// 擠型編號
        /// </summary>
        [Display(Name = "擠型編號", Order = 7)]
        public string CrowdedNumber
        {
            get { return (string)GetValue(CrowdedNumberProperty); }
            set { SetValue(CrowdedNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CrowdedNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CrowdedNumberProperty =
            DependencyProperty.Register("CrowdedNumber", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region Material Description 材料說明

        /// <summary>
        /// 材料說明
        /// </summary>
        [Display(Name = "材料說明", Order = 8)]
        public string MaterialDescription
        {
            get { return (string)GetValue(MaterialDescriptionProperty); }
            set { SetValue(MaterialDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaterialDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialDescriptionProperty =
            DependencyProperty.Register("MaterialDescription", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));



        #endregion

        #region Cut Length 裁切長度

        /// <summary>
        /// 裁切長度
        /// </summary>
        [Display(Name = "裁切長度", Order = 9)]
        public string CutLength
        {
            get { return (string)GetValue(CutLengthProperty); }
            set { SetValue(CutLengthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CutLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CutLengthProperty =
            DependencyProperty.Register("CutLength", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region Single Number 單樘數量

        /// <summary>
        /// 擠型編號
        /// </summary>
        [Display(Name = "單樘數量", Order = 10)]
        public decimal SingleNumber
        {
            get { return (decimal)GetValue(SingleNumberProperty); }
            set { SetValue(SingleNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SingleNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SingleNumberProperty =
            DependencyProperty.Register("SingleNumber", typeof(decimal), typeof(BOMViewModel), new PropertyMetadata((decimal)0));


        #endregion

        #region TotalDemand 總需求量

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "總需求量", Order = 11)]
        public decimal TotalDemand
        {
            get { return (decimal)GetValue(TotalDemandProperty); }
            set { SetValue(TotalDemandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalDemand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalDemandProperty =
            DependencyProperty.Register("TotalDemand", typeof(decimal), typeof(BOMViewModel), new PropertyMetadata((decimal)0));


        #endregion

        #region 備註

        [Display(Name = "備註", Order = 12)]
        public string Comment
        {
            get { return (string)GetValue(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Comment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentProperty =
            DependencyProperty.Register("Comment", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region 位置

        [Display(Name = "位置", Order = 13)]
        public string Postion
        {
            get { return (string)GetValue(PostionProperty); }
            set { SetValue(PostionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Postion.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostionProperty =
            DependencyProperty.Register("Postion", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region North Tower Demand 北塔需求量

        /// <summary>
        /// 北塔需求量
        /// </summary>
        [Display(Name = "北塔需求量", Order = 3)]
        public int NorthTowerDemand
        {
            get { return (int)GetValue(NorthTowerDemandProperty); }
            set { SetValue(NorthTowerDemandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NorthTowerDemand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NorthTowerDemandProperty =
            DependencyProperty.Register("NorthTowerDemand", typeof(int), typeof(BOMViewModel), new PropertyMetadata(0));


        #endregion

        #region South Tower Demand

        /// <summary>
        /// 南塔需求量
        /// </summary>
        [Display(Name = "南塔需求量", Order = 4)]
        public int SouthTowerDemand
        {
            get { return (int)GetValue(SouthTowerDemandProperty); }
            set { SetValue(SouthTowerDemandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SouthTowerDemand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SouthTowerDemandProperty =
            DependencyProperty.Register("SouthTowerDemand", typeof(int), typeof(BOMViewModel), new PropertyMetadata(0));


        #endregion

        #region 異動時間

        //[Display(Name = "異動時間", Order = 14)]
        public DateTime? LastUpdateTime
        {
            get { return (DateTime?)GetValue(LastUpdateTimeProperty); }
            set { SetValue(LastUpdateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateTimeProperty =
            DependencyProperty.Register("LastUpdateTime", typeof(DateTime?), typeof(BOMViewModel), new PropertyMetadata(new DateTime(1900, 1, 1)));


        #endregion

        #region 異動人員

        //[Display(Name = "異動人員", Order = 15)]
        public string LastUpdateUser
        {
            get { return (string)GetValue(LastUpdateUserProperty); }
            set { SetValue(LastUpdateUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdateUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateUserProperty =
            DependencyProperty.Register("LastUpdateUser", typeof(string), typeof(BOMViewModel), new PropertyMetadata(string.Empty));


        #endregion

        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is BOM)
                {
                    BOM data = (BOM)entity;
                    BindingFromModel(data, this);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
