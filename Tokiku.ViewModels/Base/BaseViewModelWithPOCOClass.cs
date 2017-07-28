using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.MVVM.Commands;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public abstract class BaseViewModelWithPOCOClass<TPOCO> : WithLoginUserBaseViewModel, ISingleBaseViewModel<TPOCO> where TPOCO : class
    {
        #region Entity
        protected TPOCO CopyofPOCOInstance;

        /// <summary>
        /// 取得資料實體的副本。
        /// </summary>
        public TPOCO Entity => CopyofPOCOInstance;


        #endregion

        public virtual IDocumentStatusViewModel Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual object Master => throw new NotImplementedException();
    }
}
