using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class AccessLogViewModel : BaseViewModelWithPOCOClass<AccessLog>
    {
        [Key]
        public long Id
        {
            get { return (long)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            RegisterDP<long, AccessLogViewModel>("Id");




        public string DataTableName
        {
            get { return (string)GetValue(DataTableNameProperty); }
            set { SetValue(DataTableNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataTableName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataTableNameProperty =
            RegisterDP<string, AccessLogViewModel>("DataTableName", string.Empty);



        /// <summary>
        /// 異動人員帳號
        /// </summary>
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(AccessLogViewModel), new PropertyMetadata(0));


        /// <summary>
        /// 存取時間
        /// </summary>
        [Column("CreateTime")]
        public DateTime UpdateTime
        {
            get { return (DateTime)GetValue(UpdateTimeProperty); }
            set { SetValue(UpdateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateTimeProperty =
            DependencyProperty.Register("UpdateTime", typeof(DateTime), typeof(AccessLogViewModel), new PropertyMetadata(DateTime.Now));


        /// <summary>
        /// 存取動作
        /// </summary>
        public string Action
        {
            get { return (string)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Action.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register("Action", typeof(string), typeof(AccessLogViewModel), new PropertyMetadata(string.Empty));



        /// <summary>
        /// 紀錄說明(變更原因說明)
        /// </summary>
        [Column("Reason")]
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(AccessLogViewModel), new PropertyMetadata(string.Empty));



        public override void SetModel(dynamic entity)
        {
            try
            {
                if (entity is AccessLog)
                {
                    CopyofPOCOInstance = (AccessLog)entity;
                    BindingFromModel(CopyofPOCOInstance, this);
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
                throw;
            }
        }


    }
}
