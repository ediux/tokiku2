using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ClientViewModelCollection : ObservableCollection<ClientViewModel>, IBaseViewModel
    {
        public ClientViewModelCollection()
        {
            HasError = false;
        }

        public ClientViewModelCollection(IEnumerable<ClientViewModel> source) : base(source)
        {

        }

        public IEnumerable<string> Errors { get; set; }
        public bool HasError { get; set; }

    }
    public class ClientViewModel : ManufacturersViewModel
    {

        public ClientViewModel() : base()
        {
            IsClient = true;
        }
        public ProjectContractViewModelCollection ProjectContract
        {
            get { return (ProjectContractViewModelCollection)GetValue(ProjectContractProperty); }
            set { SetValue(ProjectContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectContract.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectContractProperty =
            DependencyProperty.Register("ProjectContract", typeof(ProjectContractViewModelCollection), typeof(ClientViewModel), new PropertyMetadata(default(ProjectContractViewModelCollection)));


    }
}
