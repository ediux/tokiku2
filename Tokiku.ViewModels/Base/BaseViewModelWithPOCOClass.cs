using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class BaseViewModelWithPOCOClass<TPOCO> : BaseViewModel where TPOCO : class
    {
        protected TPOCO CopyofPOCOInstance;

        public override void Initialized()
        {
            base.Initialized();

            CopyofPOCOInstance = Activator.CreateInstance<TPOCO>();
            EntityType = typeof(TPOCO);
        }

        public virtual Type EntityType
        {
            get { return (Type)GetValue(EntityTypeProperty); }
            set { SetValue(EntityTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EntityType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EntityTypeProperty =
            DependencyProperty.Register("EntityType", typeof(Type), typeof(BaseViewModelWithPOCOClass<TPOCO>), new PropertyMetadata(typeof(TPOCO)));

        /// <summary>
        /// 將具備POCO特性的資料類別實體的內容抄寫到目前檢視模型中。
        /// </summary>
        /// <param name="entity"></param>
        public override void SetModel(dynamic entity)
        {
            try
            {
                if( entity is TPOCO)
                {
                    TPOCO data = (TPOCO)entity;
                    CopyofPOCOInstance = data;
                    BindingFromModel(data, this);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
