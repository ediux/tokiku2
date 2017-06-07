using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        public virtual void StartUp_Query()
        {
            Query();
        }

        /// <summary>
        /// 針對某的特定條件查詢
        /// </summary>
        /// <typeparam name="T">資料實體物件型別</typeparam>
        /// <param name="filiter">Lamba表示式，代表Where查詢條件。</param>
        public virtual void Query(Expression<Func<TView, bool>> filiter)
        {
            var temp = Items.AsQueryable().Where(filiter).ToList();
            Clear();

            foreach (var item in temp)
            {
                Add(item);
            }
        }
        public virtual void SaveModel()
        {           
        }

        /// <summary>
        /// 查詢全部資料
        /// </summary>
        public virtual void Query()
        {

        }

        /// <summary>
        /// 重新整理檢視模型
        /// </summary>
        public virtual void Refresh()
        {
            Query();
        }

        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        /// <param name="entity"></param>
        protected TView BindingFromModel<TB>(TB entity) where TB : class
        {

            TView ViewModel = default(TView);
            try
            {
                if (entity == null)
                    return ViewModel;

                ViewModel = Activator.CreateInstance<TView>();

                Type t = entity.GetType();
                Type ct = ViewModel.GetType();
#if DEBUG
                Debug.WriteLine("BindingFromModel");
                Debug.WriteLine(string.Format("資料實體{0},檢視模型為{1}", t.Name, ct.Name));
                Debug.WriteLine("開始抄寫.");
#endif
                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    try
                    {
                        var ctProp = ct.GetProperty(prop.Name);

                        if (ctProp != null)
                        {

                            if (prop.PropertyType == ctProp.PropertyType)
                            {

                                var entityvalue = prop.GetValue(entity);
                                var value = ctProp.GetValue(ViewModel);

#if DEBUG
                                Debug.Write(string.Format("資料實體屬性 {0}({2}) 內容值為 {1}(null).\n", prop.Name, entityvalue, prop.PropertyType.Name));
                                Debug.Write(string.Format("檢視模型屬性 {0}({2}) 內容值為 {1}(null).\n", ctProp.Name, value, ctProp.PropertyType.Name));
#endif

                                ctProp.SetValue(ViewModel, entityvalue);
                            }
                        }
                    }
#if DEBUG
                    catch (Exception ex)
#else
                    catch
#endif

                    {
#if DEBUG
                        Debug.WriteLine(ex.Message);

#endif
                        continue;
                    }

                }
#if DEBUG
                Debug.WriteLine("結束抄寫.");
#endif

            }
            catch (Exception ex)
            {

                if(ViewModel==null)
                    ViewModel = Activator.CreateInstance<TView>();

                ViewModel.Errors = new string[] { ex.Message + "," + ex.StackTrace };
            }

            return ViewModel;
        }

        /// <summary>
        /// 將檢視模型的內容抄寫到非資料實體模型物件。
        /// </summary>
        /// <typeparam name="T">要抄寫的目標物件型別</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected void CopyToModel<TB>(TB entity, TView ViewModel) where TB : class
        {
            try
            {

                Type CurrentViewModelType = ViewModel.GetType();
                Type TargetEntity = entity.GetType();
#if DEBUG
                Debug.WriteLine("CopyToModel");
                Debug.WriteLine(string.Format("資料實體{0},檢視模型為{1}", TargetEntity.Name, CurrentViewModelType.Name));
                Debug.WriteLine("開始抄寫.");
#endif
                var CurrentViewModel_Property = CurrentViewModelType.GetProperties();

                foreach (var ViewModelProperty in CurrentViewModel_Property)
                {
                    try
                    {
                        var EntityProperty = TargetEntity.GetProperty(ViewModelProperty.Name);
                        if (EntityProperty != null)
                        {
                            var entityvalue = EntityProperty.GetValue(entity);
                            var value = ViewModelProperty.GetValue(ViewModel);

                            if (EntityProperty.PropertyType.IsGenericType && EntityProperty.PropertyType.GetGenericTypeDefinition().Name == (typeof(ICollection<>).Name))
                            {
                                continue;
                            }



                            if (ViewModelProperty.PropertyType.IsGenericType && ViewModelProperty.PropertyType.GetGenericTypeDefinition().Name == (typeof(ObservableCollection<>).Name))
                            {
                                continue;
                            }

                            if (ViewModelProperty.PropertyType.BaseType.IsGenericType && ViewModelProperty.PropertyType.BaseType.GetGenericTypeDefinition().Name == (typeof(ObservableCollection<>).Name))
                            {
                                continue;
                            }
#if DEBUG
                            Debug.WriteLine(string.Format("資料實體屬性 {0}({2}) 內容值為 {1}.\n", EntityProperty.Name, entityvalue, EntityProperty.PropertyType.Name));
                            Debug.WriteLine(string.Format("檢視模型屬性 {0}({2}) 內容值為 {1}.\n", ViewModelProperty.Name, value, ViewModelProperty.PropertyType.Name));
#endif
                            if (value != null && !value.Equals(entityvalue))
                            {
                                EntityProperty.SetValue(entity, value);
                            }
#if DEBUG
                            Debug.WriteLine(string.Format("抄寫後資料實體屬性 {0}({2}) 內容值為 {1}.\n", EntityProperty.Name, EntityProperty.GetValue(entity), EntityProperty.PropertyType.Name));
#endif
                        }
                    }
                    catch (Exception ex)
                    {
                        setErrortoModel(this, ex);
                        continue;
                    }

                }
#if DEBUG
                Debug.WriteLine("結束抄寫.");
#endif

            }
            catch (Exception ex)
            {
                if (ViewModel != null)
                    ViewModel.Errors = new string[] { ex.Message + "," + ex.StackTrace };
            }
        }
    }
}
