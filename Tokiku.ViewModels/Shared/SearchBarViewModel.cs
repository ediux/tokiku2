using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace Tokiku.ViewModels
{
    public class SearchBarViewModel : BaseViewModel, ISearchBarViewModel
    {
        public SearchBarViewModel()
        {
            _QueryCommand = new RelayCommand(Query);
            _RefreshCommand = new RelayCommand(Refresh);
            _RefreshCommand = new RelayCommand(Reset);
        }

        private string _Prefix = string.Empty;

        public string Prefix { get => _Prefix; set { _Prefix = value; RaisePropertyChanged("Prefix"); } }

        private void Query()
        {
            try
            {
                if (!string.IsNullOrEmpty(Prefix))
                    Messenger.Default.Send(SearchText, string.Format("SearchBar_Query_{0}", Prefix));
                else
                    Messenger.Default.Send(SearchText, "SearchBar_Query");

            }
            catch (Exception)
            {

            }

        }

        private void Refresh()
        {
            try
            {
                if (!string.IsNullOrEmpty(Prefix))
                    Messenger.Default.Send(SearchText, string.Format("SearchBar_Refresh_{0}", Prefix));
                else
                    Messenger.Default.Send(SearchText, "SearchBar_Refresh");
            }
            catch (Exception)
            {

            }

        }

        private void Reset()
        {
            try
            {
                if (!string.IsNullOrEmpty(Prefix))
                    Messenger.Default.Send(SearchText, string.Format("SearchBar_Reset_{0}", Prefix));
                else
                    Messenger.Default.Send(SearchText, "SearchBar_Reset");
            }
            catch (Exception)
            {

            }

        }
        private string _SearchText = string.Empty;
        public string SearchText { get => _SearchText; set { _SearchText = value; RaisePropertyChanged("SearchText"); } }

        private ICommand _QueryCommand;
        public ICommand QueryCommand { get => _QueryCommand; set => _QueryCommand = value; }
        private ICommand _RefreshCommand = null;
        public ICommand RefreshCommand { get => _RefreshCommand; set => _RefreshCommand = value; }
        private ICommand _ResetCommand;
        public ICommand ResetCommand { get => _ResetCommand; set => _ResetCommand = value; }

    }
}
