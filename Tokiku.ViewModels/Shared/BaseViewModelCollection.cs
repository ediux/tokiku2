using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public abstract class BaseViewModelCollection<TView> : ObservableCollection<TView>, IBaseViewModel where TView : IBaseViewModel
    {
        public BaseViewModelCollection()
        {
            Initialized();
        }

        public BaseViewModelCollection(IEnumerable<TView> source) : base(source)
        {
            Initialized();
        }
        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model">檢視模型型別。</param>
        /// <param name="ex">例外錯誤狀況執行個體。</param>
        protected static void setErrortoModel(BaseViewModelCollection<TView> model, Exception ex)
        {
            if (model == null)
                model = (BaseViewModelCollection<TView>)Activator.CreateInstance(model.GetType());

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { ex.Message, ex.StackTrace };

        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        protected static void setErrortoModel(BaseViewModelCollection<TView> model, string Message)
        {
            if (model == null)
                model = (BaseViewModelCollection<TView>)Activator.CreateInstance(model.GetType());

            if (model == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { Message };
        }


        /// <summary>
        /// 錯誤訊息。
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
        /// <summary>
        /// 指出是否發生錯誤。
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// 檢視模型初始化作業
        /// </summary>
        public virtual void Initialized()
        {
            Errors = null;
            HasError = false;
        }

        /// <summary>
        /// 在啟動時的查詢動作
        /// </summary>
        public abstract void StartUp_Query();

        /// <summary>
        /// 針對某的特定條件查詢
        /// </summary>
        /// <typeparam name="T">資料實體物件型別</typeparam>
        /// <param name="filiter">Lamba表示式，代表Where查詢條件。</param>
        public abstract void Query<T>(Expression<Func<T, bool>> filiter) where T : class;

        /// <summary>
        /// 重新整理檢視模型
        /// </summary>
        public abstract void Refresh();
        
    }
}
