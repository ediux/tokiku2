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
    public class ConstructionAtlasViewModel : BaseViewModelWithPOCOClass<ConstructionAtlas>
    {

        public ConstructionAtlasViewModel()
        {

        }
        public ConstructionAtlasViewModel(ConstructionAtlas entity):base(entity)
        {

        }
        


        /// <summary>
        /// 專案合約編號
        /// </summary>
        public Guid? ProjectContractId
        {
            get { return CopyofPOCOInstance.ProjectContractId; }
            set { CopyofPOCOInstance.ProjectContractId = value; RaisePropertyChanged("ProjectContractId"); }
        }

      

        /// <summary>
        /// 圖名
        /// </summary>
        public string ImageName
        {
            get { return CopyofPOCOInstance.ImageName; }
            set { CopyofPOCOInstance.ImageName = value;RaisePropertyChanged("ImageName"); }
        }

      


        /// <summary>
        /// 版次
        /// </summary>
        public int Edition
        {
            get { return CopyofPOCOInstance.Edition; }
            set { CopyofPOCOInstance.Edition = value;RaisePropertyChanged("Edition"); }
        }




        /// <summary>
        /// 送審日期
        /// </summary>
        public DateTime SubmissionDate
        {
            get { return CopyofPOCOInstance.SubmissionDate; }
            set { CopyofPOCOInstance.SubmissionDate = value; RaisePropertyChanged("SubmissionDate"); }
        }

   



        /// <summary>
        /// 送審文號
        /// </summary>
        public string SubmitCertificateNumber
        {
            get { return CopyofPOCOInstance.SubmitCertificateNumber; }
            set { CopyofPOCOInstance.SubmitCertificateNumber = value;RaisePropertyChanged("SubmitCertificateNumber"); }
        }



        /// <summary>
        /// 回覆日期
        /// </summary>
        public DateTime? ReplyDate
        {
            get { return CopyofPOCOInstance.ReplyDate; }
            set { CopyofPOCOInstance.ReplyDate = value; RaisePropertyChanged("ReplyDate"); }
        }

   


        /// <summary>
        /// 回覆文號
        /// </summary>
        public string ReplyNumber
        {
            get { return CopyofPOCOInstance.ReplyNumber; }
            set { CopyofPOCOInstance.ReplyNumber = value;RaisePropertyChanged("ReplyNumber"); }
        }

   

        /// <summary>
        /// 回覆內容
        /// </summary>
        public int ReplyContent
        {
            get { return CopyofPOCOInstance.ReplyContent; }
            set { CopyofPOCOInstance.ReplyContent = value;RaisePropertyChanged("ReplyContent"); }
        }

 

        /// <summary>
        /// 完稿
        /// </summary>
        public bool Finalized
        {
            get { return CopyofPOCOInstance.Finalized; }
            set { CopyofPOCOInstance.Finalized = value;RaisePropertyChanged("Finalized"); }
        }

   


        /// <summary>
        /// 備註
        /// </summary>
        public string Comment
        {
            get { return CopyofPOCOInstance.Comment;
            }
            set { CopyofPOCOInstance.Comment = value; RaisePropertyChanged("Comment"); }
        }

    

       

        


      

       


     



        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        ConstructionAtlas data = (ConstructionAtlas)entity;
        //        BindingFromModel(data, this);
        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(this, ex);
        //    }
        //}
    }
}
