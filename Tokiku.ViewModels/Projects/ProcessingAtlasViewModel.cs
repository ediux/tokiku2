using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ProcessingAtlasViewModel : BaseViewModel
    {


        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(ProcessingAtlasViewModel), new PropertyMetadata(Guid.Empty));




        public Guid ProjectContractId
        {
            get { return (Guid)GetValue(ProjectContractIdProperty); }
            set { SetValue(ProjectContractIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectContractId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectContractIdProperty =
            DependencyProperty.Register("ProjectContractId", typeof(Guid), typeof(ProcessingAtlasViewModel), new PropertyMetadata(Guid.Empty));




        public int Order
        {
            get { return (int)GetValue(OrderProperty); }
            set { SetValue(OrderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Order.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderProperty =
            DependencyProperty.Register("Order", typeof(int), typeof(ProcessingAtlasViewModel), new PropertyMetadata(1));



        public int Atlas
        {
            get { return (int)GetValue(AtlasProperty); }
            set { SetValue(AtlasProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Atlas.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AtlasProperty =
            DependencyProperty.Register("Atlas", typeof(int), typeof(ProcessingAtlasViewModel), new PropertyMetadata(1));




        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(ProcessingAtlasViewModel), new PropertyMetadata(string.Empty));


        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(ProcessingAtlasViewModel), new PropertyMetadata(DateTime.Now));



        /// <summary>
        /// 建立人員
        /// </summary>
        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(ProcessingAtlasViewModel), new PropertyMetadata(default(Guid)));




        public int UpdateTimes
        {
            get { return (int)GetValue(UpdateTimesProperty); }
            set { SetValue(UpdateTimesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdateTimes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateTimesProperty =
            DependencyProperty.Register("UpdateTimes", typeof(int), typeof(ProcessingAtlasViewModel), new PropertyMetadata(0));




        public DateTime? LastUpdate
        {
            get { return (DateTime?)GetValue(LastUpdateProperty); }
            set { SetValue(LastUpdateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdateProperty =
            DependencyProperty.Register("LastUpdate", typeof(DateTime?), typeof(ProcessingAtlasViewModel), new PropertyMetadata(DateTime.Now));




        public DateTime? ConstructionOrderChangeDate
        {
            get { return (DateTime?)GetValue(ConstructionOrderChangeDateProperty); }
            set { SetValue(ConstructionOrderChangeDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConstructionOrderChangeDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConstructionOrderChangeDateProperty =
            DependencyProperty.Register("ConstructionOrderChangeDate", typeof(DateTime?), typeof(ProcessingAtlasViewModel), new PropertyMetadata(DateTime.Now));

        public override void Initialized()
        {
            base.Initialized();
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public override void SetModel(dynamic entity)
        {
            try
            {
                ProcessingAtlas data = (ProcessingAtlas)entity;
                BindingFromModel(data, this);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
