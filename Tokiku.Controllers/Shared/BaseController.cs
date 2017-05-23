using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public abstract class BaseController
    {       
        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        protected TView BindingFromModel<T, TView>(T entity) where T : class where TView : BaseViewModel
        {
            TView ViewModel = Activator.CreateInstance<TView>();

            try
            {
                Type t = typeof(T);
                Type ct = typeof(TView);

                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    var ctProp = ct.GetProperty(prop.Name);

                    if (ctProp != null)
                    {
                        ctProp.SetValue(ViewModel, prop.GetValue(entity));
                    }
                }

                ViewModel.IsEditorMode = false;
                ViewModel.CanCreateNew = true;
                ViewModel.CanSave = false;

                ViewModel.IsSaved = false;
                ViewModel.IsModify = false;
                ViewModel.IsNew = false;

                return ViewModel;
            }
            catch (Exception ex)
            {
                ViewModel.Error = ex;
                ViewModel.HasError = true;
                return ViewModel;
            }

        }

        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        protected TView BindingFromNotModel<T, TView>(T entity) where T : class where TView : class
        {
            TView ViewModel = Activator.CreateInstance<TView>();

            try
            {
                Type t = typeof(T);
                Type ct = typeof(TView);

                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    var ctProp = ct.GetProperty(prop.Name);

                    if (ctProp != null)
                    {
                        ctProp.SetValue(ViewModel, prop.GetValue(entity));
                    }
                }
                
                return ViewModel;
            }
            catch
            {
                throw;
            }

        }


        /// <summary>
        /// 將檢視模型的內容抄寫到資料實體模型。
        /// </summary>
        /// <typeparam name="T">要抄寫的目標物件型別</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected void CopyToModel<T, TView>(T entity,TView ViewModel) where T : class where TView : BaseViewModel
        {

            try
            {
                Type t = typeof(TView);
                Type ct = typeof(T);

                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    var ctProp = ct.GetProperty(prop.Name);
                    if (ctProp != null)
                    {
                        ctProp.SetValue(entity, prop.GetValue(this));
                    }
                }                
            }
            catch (Exception ex)
            {
                ViewModel.Error = ex;
                ViewModel.HasError = true;                
            }
        }

        protected void CopyToNotModel<T, TView>(T entity, TView ViewModel) where T : class where TView : class
        {

            try
            {
                Type t = typeof(TView);
                Type ct = typeof(T);

                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    var ctProp = ct.GetProperty(prop.Name);
                    if (ctProp != null)
                    {
                        ctProp.SetValue(entity, prop.GetValue(this));
                    }
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
