using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{

    public class ToolbarButtonsViewModel : DependencyObject , IToolbarButtonsViewModel
    {
        /// <summary>
        /// 啟用編輯模式
        /// </summary>
        public virtual void EnableEditor()
        {
            CanSave = true;
        }

        /// <summary>
        /// 關閉編輯模式
        /// </summary>
        public virtual void DisabledEditor()
        {

            CanSave = false;
        }

        /// <summary>
        /// 指出是否可以建立新資料(F1)
        /// </summary>
        public bool CanNew
        {
            get { return (bool)GetValue(CanNewProperty); }
            set { SetValue(CanNewProperty, value); RaisePropertyChanged("CanNew"); }
        }

        // Using a DependencyProperty as the backing store for CanNew.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanNewProperty =
            DependencyProperty.Register("CanNew", typeof(bool), typeof(ToolbarButtonsViewModel));

        /// <summary>
        /// 指出是否可以被編輯(F2)
        /// </summary>
        public bool CanEdit
        {
            get { return (bool)GetValue(CanEditProperty); }
            set { SetValue(CanEditProperty, value); RaisePropertyChanged("CanEdit"); }
        }

        // Using a DependencyProperty as the backing store for CanEdit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanEditProperty =
            DependencyProperty.Register("CanEdit", typeof(bool), typeof(ToolbarButtonsViewModel));


        /// <summary>
        /// 指出是否可以被刪除(停用)
        /// </summary>
        public bool CanDelete
        {
            get { return (bool)GetValue(CanDeleteProperty); }
            set { SetValue(CanDeleteProperty, value); RaisePropertyChanged("CanDelete"); }
        }

        // Using a DependencyProperty as the backing store for CanDelete.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanDeleteProperty =
            DependencyProperty.Register("CanDelete", typeof(bool), typeof(ToolbarButtonsViewModel), new PropertyMetadata(false));

        public static readonly DependencyProperty CanSaveProperty = DependencyProperty.Register("CanSave", typeof(bool), typeof(ToolbarButtonsViewModel));

        /// <summary>
        /// 指出是否可以存檔?(F3)
        /// </summary>
        public bool CanSave
        {
            get
            {
                return (bool)GetValue(CanSaveProperty);
            }
            set
            {
                SetValue(CanSaveProperty, value);
                RaisePropertyChanged("CanSave");
            }
        }

        public bool CanQuery
        {
            get { return (bool)GetValue(CanQueryProperty); }
            set { SetValue(CanQueryProperty, value); RaisePropertyChanged("CanQuery"); }
        }

        // Using a DependencyProperty as the backing store for CanQuery.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanQueryProperty =
            DependencyProperty.Register("CanQuery", typeof(bool), typeof(ToolbarButtonsViewModel), new PropertyMetadata(false
                ));



        public bool CanCommit
        {
            get { return (bool)GetValue(CanCommitProperty); }
            set { SetValue(CanCommitProperty, value); RaisePropertyChanged("CanCommit"); }
        }

        // Using a DependencyProperty as the backing store for CanQuery.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanCommitProperty =
            DependencyProperty.Register("CanCommit", typeof(bool), typeof(ToolbarButtonsViewModel), new PropertyMetadata(false
                ));




        public bool CanUseFeatures
        {
            get { return (bool)GetValue(CanUseFeaturesProperty); }
            set { SetValue(CanUseFeaturesProperty, value); RaisePropertyChanged("CanUseFeatures"); }
        }

        // Using a DependencyProperty as the backing store for CanUseFeatures.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanUseFeaturesProperty =
            DependencyProperty.Register("CanUseFeatures", typeof(bool), typeof(ToolbarButtonsViewModel), new PropertyMetadata(false
                ));



        public bool CanRunExcel
        {
            get { return (bool)GetValue(CanRunExcelProperty); }
            set { SetValue(CanRunExcelProperty, value); RaisePropertyChanged("CanRunExcel"); }
        }

        // Using a DependencyProperty as the backing store for CanRunExcel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanRunExcelProperty =
            DependencyProperty.Register("CanRunExcel", typeof(bool), typeof(ToolbarButtonsViewModel), new PropertyMetadata(false
                ));



        public bool CanPrint
        {
            get { return (bool)GetValue(CanPrintProperty); }
            set { SetValue(CanPrintProperty, value); RaisePropertyChanged("CanPrint"); }
        }

        // Using a DependencyProperty as the backing store for CanPrint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanPrintProperty =
            DependencyProperty.Register("CanPrint", typeof(bool), typeof(ToolbarButtonsViewModel), new PropertyMetadata(true
                ));





        public bool CanCancel
        {
            get { return (bool)GetValue(CanCancelProperty); }
            set { SetValue(CanCancelProperty, value); RaisePropertyChanged("CanCancel"); }
        }

        // Using a DependencyProperty as the backing store for CanCancel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanCancelProperty =
            DependencyProperty.Register("CanCancel", typeof(bool), typeof(ToolbarButtonsViewModel), new PropertyMetadata(false
                ));




        public bool CanClose
        {
            get { return (bool)GetValue(CanCloseProperty); }
            set { SetValue(CanCloseProperty, value); RaisePropertyChanged("CanClose"); }
        }

        // Using a DependencyProperty as the backing store for CanClose.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanCloseProperty =
            DependencyProperty.Register("CanClose", typeof(bool), typeof(ToolbarButtonsViewModel), new PropertyMetadata(false
                ));



        public bool CanAddColumn
        {
            get { return (bool)GetValue(CanAddColumnProperty); }
            set { SetValue(CanAddColumnProperty, value); RaisePropertyChanged("CanAddColumn"); }
        }

        // Using a DependencyProperty as the backing store for CanAddColumn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddColumnProperty =
            DependencyProperty.Register("CanAddColumn", typeof(bool), typeof(ToolbarButtonsViewModel), new PropertyMetadata(false
               ));




        public bool CanAddRow
        {
            get { return (bool)GetValue(CanAddRowProperty); }
            set { SetValue(CanAddRowProperty, value); RaisePropertyChanged("CanAddRow"); }
        }

        // Using a DependencyProperty as the backing store for CanAddRow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddRowProperty =
            DependencyProperty.Register("CanAddRow", typeof(bool), typeof(ToolbarButtonsViewModel), new PropertyMetadata(false
                ));

        #region PropertyChanged 事件
        /// <summary>
        /// 屬性變更事件。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引發屬性變更事件。
        /// </summary>
        /// <param name="PropertyName">發生變更的屬性名稱。</param>
        protected void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion
    }
}
