using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.ViewModels;

namespace Tokiku.MVVM.Tools
{
    public static class Tools
    {
        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        /// <param name="entity"></param>
        public static TView BindingFromModel<TView, TB>(this TView baseobj, TB entity) where TB : class where TView : IBaseViewModel
        {
            TView ViewModel = default(TView);

            try
            {
                if (entity == null)
                    return ViewModel;

                ViewModel = Activator.CreateInstance<TView>();

                Type t = entity.GetType();
                Type ct = ViewModel.GetType();

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

                                ctProp.SetValue(ViewModel, entityvalue);
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }

                }

            }
            catch (Exception ex)
            {

                if (ViewModel == null)
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
        public static void CopyToModel<TView, TB>(this TView ViewModel, TB entity) where TB : class where TView : IBaseViewModel
        {
            try
            {

                Type CurrentViewModelType = ViewModel.GetType();
                Type TargetEntity = entity.GetType();

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

                            if (value != null && !value.Equals(entityvalue))
                            {
                                EntityProperty.SetValue(entity, value);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        setErrortoModel(ViewModel, ex);
                        continue;
                    }

                }

            }
            catch (Exception ex)
            {
                if (ViewModel != null)
                    ViewModel.Errors = new string[] { ex.Message + "," + ex.StackTrace };
            }
        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model">檢視模型型別。</param>
        /// <param name="ex">例外錯誤狀況執行個體。</param>
        public static void setErrortoModel<TView>(this TView model, Exception ex) where TView : IBaseViewModel
        {
            if (model == null)
                model = (TView)Activator.CreateInstance(model.GetType());

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { ex.Message, ex.StackTrace };

        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        public static void setErrortoModel<TView>(this TView model, string Message) where TView : IBaseViewModel
        {
            if (model == null)
                model = (TView)Activator.CreateInstance(model.GetType());

            if (model == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { Message };
        }
    }
}
