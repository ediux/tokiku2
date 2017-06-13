using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MoldsViewModel : BaseViewModelWithPOCOClass<Molds>
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
            DependencyProperty.Register("Id", typeof(Guid), typeof(MoldsViewModel), new PropertyMetadata(Guid.NewGuid()));

        #endregion

        #region Open Date

        /// <summary>
        /// 開模日期
        /// </summary>
        public DateTime OpenDate
        {
            get { return (DateTime)GetValue(OpenDateProperty); }
            set { SetValue(OpenDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenDateProperty =
            DependencyProperty.Register("OpenDate", typeof(DateTime), typeof(MoldsViewModel), new PropertyMetadata(default(DateTime)));


        #endregion

        #region LegendMoldReduction

        /// <summary>
        /// 圖例
        /// </summary>
        public string LegendMoldReduction
        {
            get { return (string)GetValue(LegendMoldReductionProperty); }
            set { SetValue(LegendMoldReductionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LegendMoldReduction.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LegendMoldReductionProperty =
            DependencyProperty.Register("LegendMoldReduction", typeof(string), typeof(MoldsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region UsePosition

        /// <summary>
        /// 使用位置
        /// </summary>
        public string UsePosition
        {
            get { return (string)GetValue(UsePositionProperty); }
            set { SetValue(UsePositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UsePosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UsePositionProperty =
            DependencyProperty.Register("UsePosition", typeof(string), typeof(MoldsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region Code

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Code.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string), typeof(MoldsViewModel), new PropertyMetadata(string.Empty));


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

        // Using a DependencyProperty as the backing store for ManufacturersId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersIdProperty =
            DependencyProperty.Register("ManufacturersId", typeof(Guid), typeof(MoldsViewModel), new PropertyMetadata(Guid.Empty));


        #endregion

        #region Manufacturers

        /// <summary>
        /// 導覽屬性:模具廠商
        /// </summary>
        public ManufacturersViewModel Manufacturers
        {
            get { return (ManufacturersViewModel)GetValue(ManufacturersProperty); }
            set { SetValue(ManufacturersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Manufacturers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersProperty =
            DependencyProperty.Register("Manufacturers", typeof(ManufacturersViewModel), typeof(MoldsViewModel), new PropertyMetadata(default(ManufacturersViewModel)));


        #endregion

        #region MaterialId


        public Guid MaterialId
        {
            get { return (Guid)GetValue(MaterialIdProperty); }
            set { SetValue(MaterialIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaterialId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialIdProperty =
            DependencyProperty.Register("MaterialId", typeof(Guid), typeof(MoldsViewModel), new PropertyMetadata(Guid.Empty));


        #endregion

        #region Material

        /// <summary>
        /// 物料主表
        /// </summary>
        public MaterialsViewModel Material
        {
            get { return (MaterialsViewModel)GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Material.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialProperty =
            DependencyProperty.Register("Material", typeof(MaterialsViewModel), typeof(MoldsViewModel), new PropertyMetadata(default(MaterialsViewModel)));


        #endregion

        #region Unit Weight

        /// <summary>
        /// 單位重(KG/M)
        /// </summary>
        public float UnitWeight
        {
            get { return (float)GetValue(UnitWeightProperty); }
            set { SetValue(UnitWeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnitWeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitWeightProperty =
            DependencyProperty.Register("UnitWeight", typeof(float), typeof(MoldsViewModel), new PropertyMetadata(0F));


        #endregion

        #region Surface Treatment

        /// <summary>
        /// 表面處理
        /// </summary>
        public string SurfaceTreatment
        {
            get { return (string)GetValue(SurfaceTreatmentProperty); }
            set { SetValue(SurfaceTreatmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SurfaceTreatment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SurfaceTreatmentProperty =
            DependencyProperty.Register("SurfaceTreatment", typeof(string), typeof(MoldsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region PaintArea

        /// <summary>
        /// 烤漆面積
        /// </summary>
        public float PaintArea
        {
            get { return (float)GetValue(PaintAreaProperty); }
            set { SetValue(PaintAreaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaintArea.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaintAreaProperty =
            DependencyProperty.Register("PaintArea", typeof(float), typeof(MoldsViewModel), new PropertyMetadata(0F));


        #endregion

        #region MembraneTreatment


        /// <summary>
        /// 皮膜處理
        /// </summary>
        public float MembraneTreatment
        {
            get { return (float)GetValue(MembraneTreatmentProperty); }
            set { SetValue(MembraneTreatmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MembraneTreatment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MembraneTreatmentProperty =
            DependencyProperty.Register("MembraneTreatment", typeof(float), typeof(MoldsViewModel), new PropertyMetadata(0F));


        #endregion

        #region MinimumYield

        /// <summary>
        /// 最低產量
        /// </summary>
        public float MinimumYield
        {
            get { return (float)GetValue(MinimumYieldProperty); }
            set { SetValue(MinimumYieldProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinimumYield.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumYieldProperty =
            DependencyProperty.Register("MinimumYield", typeof(float), typeof(MoldsViewModel), new PropertyMetadata(0F));


        #endregion

        #region ProductionIngot


        /// <summary>
        /// 模具費用
        /// </summary>
        public float ProductionIngot
        {
            get { return (float)GetValue(ProductionIngotProperty); }
            set { SetValue(ProductionIngotProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProductionIngot.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductionIngotProperty =
            DependencyProperty.Register("ProductionIngot", typeof(float), typeof(MoldsViewModel), new PropertyMetadata(0F));


        #endregion

        #region TotalOrderWeight

        /// <summary>
        /// 訂單總重量
        /// </summary>
        public float TotalOrderWeight
        {
            get { return (float)GetValue(TotalOrderWeightProperty); }
            set { SetValue(TotalOrderWeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalOrderWeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalOrderWeightProperty =
            DependencyProperty.Register("TotalOrderWeight", typeof(float), typeof(MoldsViewModel), new PropertyMetadata(0F));


        #endregion

        #region MoldUseStatusId

        /// <summary>
        /// 模具使用狀況
        /// </summary>
        public int MoldUseStatusId
        {
            get { return (int)GetValue(MoldUseStatusIdProperty); }
            set { SetValue(MoldUseStatusIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MoldUseStatusId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MoldUseStatusIdProperty =
            DependencyProperty.Register("MoldUseStatusId", typeof(int), typeof(MoldsViewModel), new PropertyMetadata(0));


        #endregion

        #region Comment


        /// <summary>
        /// 備註
        /// </summary>
        public string Comment
        {
            get { return (string)GetValue(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Comment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentProperty =
            DependencyProperty.Register("Comment", typeof(string), typeof(MoldsViewModel), new PropertyMetadata(string.Empty));


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
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(MoldsViewModel), new PropertyMetadata(DateTime.Now));


        #endregion

        #region CreateUserId


        /// <summary>
        /// 建立人員ID
        /// </summary>
        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(MoldsViewModel), new PropertyMetadata(Guid.Empty));


        #endregion

        #region CreateUser
        /// <summary>
        /// 建立的使用者
        /// </summary>
        public UserViewModel CreateUser
        {
            get { return (UserViewModel)GetValue(CreateUserProperty); }
            set { SetValue(CreateUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserProperty =
            DependencyProperty.Register("CreateUser", typeof(UserViewModel), typeof(MoldsViewModel), new PropertyMetadata(default(UserViewModel)));

        #endregion

        #region Materials

        /// <summary>
        /// 材質
        /// </summary>
        public MaterialsViewModel Materials
        {
            get { return (MaterialsViewModel)GetValue(MaterialsProperty); }
            set { SetValue(MaterialsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Materials.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaterialsProperty =
            DependencyProperty.Register("Materials", typeof(MaterialsViewModel), typeof(MoldsViewModel), new PropertyMetadata(0));


        #endregion

        #region LastUpdateTime


        /// <summary>
        /// 異動時間
        /// </summary>
        public DateTime? LastUpdateTime
        {
            get { return (DateTime?)GetValue(LastUpdateTimeProperty); }
            set { SetValue(LastUpdateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateTimeProperty =
            DependencyProperty.Register("LastUpdateTime", typeof(DateTime?), typeof(MoldsViewModel), new PropertyMetadata(DateTime.Now));


        #endregion

        #region MoldUseStatus

        /// <summary>
        /// 模具使用狀況
        /// </summary>
        public MoldUseStatusViewModel MoldUseStatus
        {
            get { return (MoldUseStatusViewModel)GetValue(MoldUseStatusProperty); }
            set { SetValue(MoldUseStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MoldUseStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MoldUseStatusProperty =
            DependencyProperty.Register("MoldUseStatus", typeof(MoldUseStatusViewModel), typeof(MoldsViewModel), new PropertyMetadata(default(MoldUseStatusViewModel)));


        #endregion

        #region ProjectName


        public string ProjectName
        {
            get { return (string)GetValue(ProjectNameProperty); }
            set { SetValue(ProjectNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectNameProperty =
            DependencyProperty.Register("ProjectName", typeof(string), typeof(MoldsViewModel), new PropertyMetadata(string.Empty));


        #endregion

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
