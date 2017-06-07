﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class EngineeringViewModelCollection : BaseViewModelCollection<EngineeringViewModel>
    {
        private Controllers.EngineeringController controller;

        public EngineeringViewModelCollection()
        {
            HasError = false;
        }

        public EngineeringViewModelCollection(IEnumerable<EngineeringViewModel> source) : base(source)
        {

        }

        public Guid ProjectContractId
        {
            get; set;
        }

        public override void Initialized()
        {
            base.Initialized();
            controller = new Controllers.EngineeringController();
        }

        public override void Query()
        {
            if (ProjectContractId != null && ProjectContractId != Guid.Empty)
            {
                var executed_result = controller.QueryAll(ProjectContractId);

                if (!executed_result.HasError)
                {
                    ClearItems();
                    foreach (var row in executed_result.Result)
                    {
                        Add(BindingFromModel(row));
                    }
                }
            }
        }      
    }

    public class EngineeringViewModel : BaseViewModel
    {
        private Controllers.EngineeringController controller = new Controllers.EngineeringController();

        #region Id
        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(EngineeringViewModel), new PropertyMetadata(Guid.NewGuid()));

        #endregion

        #region ProjectContractId
        public Guid ProjectContractId
        {
            get { return (Guid)GetValue(ProjectContractIdProperty); }
            set { SetValue(ProjectContractIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectContractId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectContractIdProperty =
            DependencyProperty.Register("ProjectContractId", typeof(Guid), typeof(EngineeringViewModel), new PropertyMetadata(Guid.Empty));

        #endregion

        #region ProjectContract
        public ProjectContractViewModel ProjectContract
        {
            get { return (ProjectContractViewModel)GetValue(ProjectContractProperty); }
            set { SetValue(ProjectContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectContractProperty =
            DependencyProperty.Register("ProjectContract", typeof(ProjectContractViewModel), typeof(EngineeringViewModel), new PropertyMetadata(default(ProjectContractViewModel)));
        #endregion

        #region Code
        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Code.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string), typeof(EngineeringViewModel), new PropertyMetadata(string.Empty));

        #endregion

        #region Name
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(EngineeringViewModel), new PropertyMetadata(string.Empty));

        #endregion

        #region StartDate
        public DateTime StartDate
        {
            get { return (DateTime)GetValue(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartDateProperty =
            DependencyProperty.Register("StartDate", typeof(DateTime), typeof(EngineeringViewModel), new PropertyMetadata(new DateTime(1900, 1, 1)));


        #endregion

        #region CompletionDate

        public DateTime CompletionDate
        {
            get { return (DateTime)GetValue(CompletionDateProperty); }
            set { SetValue(CompletionDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompletionDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompletionDateProperty =
            DependencyProperty.Register("CompletionDate", typeof(DateTime), typeof(EngineeringViewModel), new PropertyMetadata(new DateTime(1900, 1, 1)));

        #endregion

        #region State
        public byte? State
        {
            get { return (byte?)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(byte?), typeof(EngineeringViewModel), new PropertyMetadata(default(byte?)));

        #endregion

        #region CreateTime
        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(EngineeringViewModel), new PropertyMetadata(DateTime.Now));

        #endregion

        #region CreateUserId

        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(EngineeringViewModel), new PropertyMetadata(default(Guid)));

        #endregion

        #region Relationship

        #region ShopFlowHistory
        /// <summary>
        /// 生產歷程
        /// </summary>
        public ShopFlowHistoryViewModelCollection ShopFlowHistory
        {
            get { return (ShopFlowHistoryViewModelCollection)GetValue(ShopFlowHistoryProperty); }
            set { SetValue(ShopFlowHistoryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShopFlowHistory.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShopFlowHistoryProperty =
            DependencyProperty.Register("ShopFlowHistory", typeof(ShopFlowHistoryViewModelCollection), typeof(EngineeringViewModel), new PropertyMetadata(default(ShopFlowHistoryViewModelCollection)));

        #endregion

        #region Compositions
        /// <summary>
        /// 施工圖集
        /// </summary>
        public CompositionsViewModelCollection Compositions
        {
            get { return (CompositionsViewModelCollection)GetValue(CompositionsProperty); }
            set { SetValue(CompositionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Compositions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompositionsProperty =
            DependencyProperty.Register("Compositions", typeof(CompositionsViewModelCollection), typeof(EngineeringViewModel), new PropertyMetadata(default(CompositionsViewModelCollection)));


        #endregion

        #region Compositions2
        /// <summary>
        /// 加工圖集
        /// </summary>
        public CompositionsViewModelCollection Compositions2
        {
            get { return (CompositionsViewModelCollection)GetValue(Compositions2Property); }
            set { SetValue(Compositions2Property, value); }
        }

        // Using a DependencyProperty as the backing store for Compositions2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Compositions2Property =
            DependencyProperty.Register("Compositions2", typeof(CompositionsViewModelCollection), typeof(EngineeringViewModel), new PropertyMetadata(default(CompositionsViewModelCollection)));

        #endregion

        #endregion


        #region Model Command Functions      

        public override void Query()
        {
            if (ProjectContractId != null && ProjectContractId != Guid.Empty)
            {
                var executed_result = controller.Query(p=>p.Id == Id);

                if (!executed_result.HasError)
                {
                    Entity.Engineering data = executed_result.Result.Single();
                    BindingFromModel(data, this);
                }
            }

        }

        public override void SaveModel()
        {

        }
        #endregion









    }
}