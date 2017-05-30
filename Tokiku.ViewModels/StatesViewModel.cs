using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
namespace Tokiku.ViewModels
{
    public class StatesViewModelCollection : ObservableCollection<StatesViewModel>,IBaseViewModel
    {
        public StatesViewModelCollection()
        {

        }

        public StatesViewModelCollection(IEnumerable<StatesViewModel> source) : base(source)
        {

        }

        private IEnumerable<string> _Errors;
        public IEnumerable<string> Errors { get => _Errors; set => _Errors = value; }
        private bool _HasError = false;
        public bool HasError { get => _HasError; set => _HasError = value; }
    }
    public class StatesViewModel : BaseViewModel
    {


        public byte Id
        {
            get { return (byte)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(byte), typeof(StatesViewModel), new PropertyMetadata((byte)0));



        public string StateName
        {
            get { return (string)GetValue(StateNameProperty); }
            set { SetValue(StateNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StateName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateNameProperty =
            DependencyProperty.Register("StateName", typeof(string), typeof(StatesViewModel), new PropertyMetadata(string.Empty));


    }
}
