using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class BaseViewModelWithPOCOClass<TPOCO> : IBaseViewModel where TPOCO : class
    {
        protected TPOCO CopyofPOCOInstance;

        public BaseViewModelWithPOCOClass()
        {
            CopyofPOCOInstance = Activator.CreateInstance<TPOCO>();
            EntityType = typeof(TPOCO);
            Initialized();
        }

        public BaseViewModelWithPOCOClass(TPOCO entity)
        {
            CopyofPOCOInstance = entity;
            EntityType = entity.GetType();
            Initialized();
        }

        public virtual void Initialized()
        {

        }

        protected Type _EntityType;

        public virtual Type EntityType
        {
            get { return _EntityType; }
            set { _EntityType = value; }
        }

        private IEnumerable<string> _Errors;
        public IEnumerable<string> Errors { get => _Errors; set { _Errors = value; if (_Errors.Any()) { _HasError = true; } } }

        private bool _HasError = false;
        public bool HasError { get => _HasError; set => _HasError = value; }

        private DocumentStatusViewModel _Status;
        public DocumentStatusViewModel Status
        {
            get => _Status;
            set
            {
                _Status = value;
                RaisePropertyChanged("Status");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引發屬性變更事件。
        /// </summary>
        /// <param name="PropertyName">發生變更的屬性名稱。</param>
        protected void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public Guid Id
        {
            get { return (Guid)_EntityType.GetProperty("Id").GetValue(CopyofPOCOInstance); }
            set { _EntityType.GetProperty("Id").SetValue(CopyofPOCOInstance, value); RaisePropertyChanged("Id"); }
        }

        /// <summary>
        /// 將來自資料庫的資料實體抄到檢視模型。
        /// </summary>
        protected void BindingFromModel(TPOCO entity)
        {
            try
            {
                if (entity == null)
                    return;

                Type t = entity.GetType();
                Type ct = GetType();

                var props = t.GetProperties();

                foreach (var prop in props)
                {
                    try
                    {
                        if (t.IsGenericType && t.GetGenericTypeDefinition().Name == (typeof(ICollection<>).Name))
                        {
                            continue;
                        }

                        if (ct.IsGenericType && ct.GetGenericTypeDefinition().Name == (typeof(ObservableCollection<>).Name))
                        {
                            continue;
                        }

                        if (ct.BaseType.IsGenericType && ct.BaseType.GetGenericTypeDefinition().Name == (typeof(ObservableCollection<>).Name))
                        {
                            continue;
                        }

                        if (ct.BaseType.IsGenericType && ct.BaseType.GetGenericTypeDefinition().Name == (typeof(BaseViewModelCollection<>).Name))
                        {
                            continue;
                        }

                        var ctProp = ct.GetProperty(prop.Name);

                        if (ctProp != null)
                        {
                            if (prop.PropertyType == ctProp.PropertyType)
                            {
                                var entityvalue = prop.GetValue(entity);
                                var value = ctProp.GetValue(this);
                                ctProp.SetValue(this, entityvalue);
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
                Errors = new string[] { ex.Message + "," + ex.StackTrace };
            }
        }

        /// <summary>
        /// 將錯誤訊息寫到檢視模型中以利顯示。
        /// </summary>
        /// <param name="model">檢視模型型別。</param>
        /// <param name="ex">例外錯誤狀況執行個體。</param>
        protected static void setErrortoModel(IBaseViewModel model, Exception ex)
        {
            if (model == null)
                model = (IBaseViewModel)Activator.CreateInstance(model.GetType());

            if (model.Errors == null)
                model.Errors = new string[] { }.AsEnumerable();

            model.Errors = new string[] { ex.Message, ex.StackTrace };

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
        /// 將具備POCO特性的資料類別實體的內容抄寫到目前檢視模型中。
        /// </summary>
        /// <param name="entity"></param>
        public virtual void SetModel(dynamic entity)
        {
            try
            {
                if (entity is TPOCO)
                {
                    TPOCO data = (TPOCO)entity;
                    CopyofPOCOInstance = data;
                    BindingFromModel(data);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        public virtual void Query()
        {
            throw new NotImplementedException();
        }

        public virtual void Refresh()
        {
            throw new NotImplementedException();
        }

        public virtual void SaveModel()
        {
            throw new NotImplementedException();
        }
    }
}
