using System;
using System.Collections.Generic;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ConstructionAtlasViewModelCollection : BaseViewModelCollection<ConstructionAtlasViewModel>
    {
        public ConstructionAtlasViewModelCollection()
        {

        }
        public ConstructionAtlasViewModelCollection(IEnumerable<ConstructionAtlasViewModel> source) : base(source)
        {

        }
    }

    /// <summary>
    /// 施工圖集檢視模型
    /// </summary>
    public class ConstructionAtlasViewModel : BaseViewModel
    {

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
            DependencyProperty.Register("Id", typeof(Guid), typeof(ConstructionAtlasViewModel), new PropertyMetadata(Guid.NewGuid()));



        /// <summary>
        /// 專案合約編號
        /// </summary>
        public Guid ProjectContractId
        {
            get { return (Guid)GetValue(ProjectContractIdProperty); }
            set { SetValue(ProjectContractIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EngineeringId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectContractIdProperty =
            DependencyProperty.Register("ProjectContractId", typeof(Guid), typeof(ConstructionAtlasViewModel), new PropertyMetadata(Guid.Empty));



        /// <summary>
        /// 圖名
        /// </summary>
        public string ImageName
        {
            get { return (string)GetValue(ImageNameProperty); }
            set { SetValue(ImageNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageNameProperty =
            DependencyProperty.Register("ImageName", typeof(string), typeof(ConstructionAtlasViewModel), new PropertyMetadata(string.Empty));



        /// <summary>
        /// 版次
        /// </summary>
        public int Edition
        {
            get { return (int)GetValue(EditionProperty); }
            set { SetValue(EditionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Edition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditionProperty =
            DependencyProperty.Register("Edition", typeof(int), typeof(ConstructionAtlasViewModel), new PropertyMetadata(1));




        /// <summary>
        /// 送審日期
        /// </summary>
        public DateTime SubmissionDate
        {
            get { return (DateTime)GetValue(SubmissionDateProperty); }
            set { SetValue(SubmissionDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SubmissionDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubmissionDateProperty =
            DependencyProperty.Register("SubmissionDate", typeof(DateTime), typeof(ConstructionAtlasViewModel), new PropertyMetadata(DateTime.Today));





        /// <summary>
        /// 送審文號
        /// </summary>
        public string SubmitCertificateNumber
        {
            get { return (string)GetValue(SubmitCertificateNumberProperty); }
            set { SetValue(SubmitCertificateNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SubmitCertificateNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubmitCertificateNumberProperty =
            DependencyProperty.Register("SubmitCertificateNumber", typeof(string), typeof(ConstructionAtlasViewModel), new PropertyMetadata(string.Empty));



        /// <summary>
        /// 回覆日期
        /// </summary>
        public DateTime? ReplyDate
        {
            get { return (DateTime?)GetValue(ReplyDateProperty); }
            set { SetValue(ReplyDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReplyDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReplyDateProperty =
            DependencyProperty.Register("ReplyDate", typeof(DateTime?), typeof(ConstructionAtlasViewModel), new PropertyMetadata(default(DateTime?)));



        /// <summary>
        /// 回覆文號
        /// </summary>
        public string ReplyNumber
        {
            get { return (string)GetValue(ReplyNumberProperty); }
            set { SetValue(ReplyNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReplyDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReplyNumberProperty =
            DependencyProperty.Register("ReplyNumber", typeof(string), typeof(ConstructionAtlasViewModel), new PropertyMetadata(string.Empty));



        /// <summary>
        /// 回覆內容
        /// </summary>
        public int ReplyContent
        {
            get { return (int)GetValue(ReplyContentProperty); }
            set { SetValue(ReplyContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReplyContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReplyContentProperty =
            DependencyProperty.Register("ReplyContent", typeof(int), typeof(ConstructionAtlasViewModel), new PropertyMetadata(1));



        /// <summary>
        /// 完稿
        /// </summary>
        public bool Finalized
        {
            get { return (bool)GetValue(FinalizedProperty); }
            set { SetValue(FinalizedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Finalized.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FinalizedProperty =
            DependencyProperty.Register("Finalized", typeof(bool), typeof(ConstructionAtlasViewModel), new PropertyMetadata(false));



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
            DependencyProperty.Register("Comment", typeof(string), typeof(ConstructionAtlasViewModel), new PropertyMetadata(string.Empty));



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
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(ConstructionAtlasViewModel), new PropertyMetadata(DateTime.Now));



        /// <summary>
        /// 建立人員
        /// </summary>
        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(ConstructionAtlasViewModel), new PropertyMetadata(default(Guid)));




        public DateTime LastUpdateDate
        {
            get { return (DateTime)GetValue(LastUpdateDateProperty); }
            set { SetValue(LastUpdateDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdateData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateDateProperty =
            DependencyProperty.Register("LastUpdateDate", typeof(DateTime), typeof(ConstructionAtlasViewModel), new PropertyMetadata(DateTime.Now));




     



        public override void SetModel(dynamic entity)
        {
            try
            {
                ConstructionAtlas data = (ConstructionAtlas)entity;
                BindingFromModel(data, this);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
