using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ViewModelBase2 : ViewModelBase, IBaseViewModel
    {
        public ViewModelBase2()
        {
            _Errors = new string[] { };
            _HasError = false;
        }

        #region Error
        private IEnumerable<string> _Errors;
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public IEnumerable<string> Errors { get => _Errors; set { _Errors = value; if (_Errors.Any()) { _HasError = true; } } }

        private bool _HasError = false;
        /// <summary>
        /// 指出是否有發生錯誤
        /// </summary>
        public bool HasError { get => _HasError; set => _HasError = value; }
        #endregion

        #region Helper Functions
        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model">檢視模型型別。</param>
        /// <param name="ex">例外錯誤狀況執行個體。</param>
        protected static void setErrortoModel(IBaseViewModel model, Exception ex)
        {
            if (model == null)
                model = (IBaseViewModel)Activator.CreateInstance(model.GetType());

            List<string> _Messages = new List<string>();
            ScanErrorMessage(ex, _Messages);

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = _Messages.AsEnumerable();

        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        protected static void setErrortoModel(IBaseViewModel model, string Message)
        {
            if (model == null)
                model = (IBaseViewModel)Activator.CreateInstance(model.GetType());

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { Message };
        }

        /// <summary>
        /// 掃描深度錯誤訊息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="messageQueue"></param>
        private static void ScanErrorMessage(Exception ex, List<string> messageQueue)
        {
            if (ex.InnerException != null)
            {
                ScanErrorMessage(ex.InnerException, messageQueue);
            }

            messageQueue.Add(ex.Message);

        }

        #endregion
    }
}
