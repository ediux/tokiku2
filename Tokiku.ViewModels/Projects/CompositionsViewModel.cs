using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class CompositionsViewModelCollection : BaseViewModelCollection<CompositionsViewModel>
    {
        public CompositionsViewModelCollection()
        {

        }
        public CompositionsViewModelCollection(IEnumerable<CompositionsViewModel> source) : base(source)
        {

        }
    }

    /// <summary>
    /// 成分表檢視表
    /// </summary>
    public class CompositionsViewModel : BaseViewModel
    {


        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(CompositionsViewModel), new PropertyMetadata(Guid.NewGuid()));




        public Guid? EngineeringId
        {
            get { return (Guid?)GetValue(EngineeringIdProperty); }
            set { SetValue(EngineeringIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EngineeringId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EngineeringIdProperty =
            DependencyProperty.Register("EngineeringId", typeof(Guid?), typeof(CompositionsViewModel), new PropertyMetadata(default(Guid?)));




        public int Order
        {
            get { return (int)GetValue(OrderProperty); }
            set { SetValue(OrderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Order.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderProperty =
            DependencyProperty.Register("Order", typeof(int), typeof(CompositionsViewModel), new PropertyMetadata(0));





        public int? CompositionTypeId
        {
            get { return (int?)GetValue(CompositionTypeIdProperty); }
            set { SetValue(CompositionTypeIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompositionTypeId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompositionTypeIdProperty =
            DependencyProperty.Register("CompositionTypeId", typeof(int?), typeof(CompositionsViewModel), new PropertyMetadata(default(int?)));




        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Code.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string), typeof(CompositionsViewModel), new PropertyMetadata(string.Empty));




        public string SpecDesc
        {
            get { return (string)GetValue(SpecDescProperty); }
            set { SetValue(SpecDescProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SpecDesc.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpecDescProperty =
            DependencyProperty.Register("SpecDesc", typeof(string), typeof(CompositionsViewModel), new PropertyMetadata(string.Empty));




        public float Amount
        {
            get { return (float)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Amount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register("Amount", typeof(float), typeof(CompositionsViewModel), new PropertyMetadata(0F));




        public string Reserved1
        {
            get { return (string)GetValue(Reserved1Property); }
            set { SetValue(Reserved1Property, value); }
        }

        // Using a DependencyProperty as the backing store for Reserved1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Reserved1Property =
            DependencyProperty.Register("Reserved1", typeof(string), typeof(CompositionsViewModel), new PropertyMetadata(string.Empty));


        public string Reserved2
        {
            get { return (string)GetValue(Reserved2Property); }
            set { SetValue(Reserved2Property, value); }
        }

        // Using a DependencyProperty as the backing store for Reserved1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Reserved2Property =
            DependencyProperty.Register("Reserved2", typeof(string), typeof(CompositionsViewModel), new PropertyMetadata(string.Empty));




        public string Reserved3
        {
            get { return (string)GetValue(Reserved3Property); }
            set { SetValue(Reserved3Property, value); }
        }

        // Using a DependencyProperty as the backing store for Reserved3.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Reserved3Property =
            DependencyProperty.Register("Reserved3", typeof(string), typeof(CompositionsViewModel), new PropertyMetadata(string.Empty));




        public string Reserved4
        {
            get { return (string)GetValue(Reserved4Property); }
            set { SetValue(Reserved4Property, value); }
        }

        // Using a DependencyProperty as the backing store for Reserved4.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Reserved4Property =
            DependencyProperty.Register("Reserved4", typeof(string), typeof(CompositionsViewModel), new PropertyMetadata(string.Empty));



        public string Reserved5
        {
            get { return (string)GetValue(Reserved5Property); }
            set { SetValue(Reserved5Property, value); }
        }

        // Using a DependencyProperty as the backing store for Reserved5.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Reserved5Property =
            DependencyProperty.Register("Reserved5", typeof(string), typeof(CompositionsViewModel), new PropertyMetadata(string.Empty));




        public int Reserved6
        {
            get { return (int)GetValue(Reserved6Property); }
            set { SetValue(Reserved6Property, value); }
        }

        // Using a DependencyProperty as the backing store for Reserved6.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Reserved6Property =
            DependencyProperty.Register("Reserved6", typeof(int), typeof(CompositionsViewModel), new PropertyMetadata(0));




        public DateTime CreateTime
        {
            get { return (DateTime)GetValue(CreateTimeProperty); }
            set { SetValue(CreateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateTimeProperty =
            DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(CompositionsViewModel), new PropertyMetadata(DateTime.Now));




        public Guid CreateUserId
        {
            get { return (Guid)GetValue(CreateUserIdProperty); }
            set { SetValue(CreateUserIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateUserId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateUserIdProperty =
            DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(CompositionsViewModel), new PropertyMetadata(default(Guid)));




        public CompositionTypesViewModelCollection CompositionTypes
        {
            get { return (CompositionTypesViewModelCollection)GetValue(CompositionTypesProperty); }
            set { SetValue(CompositionTypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompositionTypes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompositionTypesProperty =
            DependencyProperty.Register("CompositionTypes", typeof(CompositionTypesViewModelCollection), typeof(CompositionsViewModel), new PropertyMetadata(default(CompositionTypesViewModelCollection)));




        public EngineeringViewModel Engineering
        {
            get { return (EngineeringViewModel)GetValue(EngineeringProperty); }
            set { SetValue(EngineeringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Engineering.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EngineeringProperty =
            DependencyProperty.Register("Engineering", typeof(EngineeringViewModel), typeof(CompositionTypesViewModel), new PropertyMetadata(default(CompositionTypesViewModelCollection)));



        //public virtual Engineering Engineering { get; set; }
    }
}
