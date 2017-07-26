using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Tokiku.ViewModels.Shared
{
    public class SearchBarViewModel : INotifyPropertyChanged
    {
        public SearchBarViewModel()
        {
            MethodName = new Stack<dynamic>();
            _QueryCommand = new QueryCommand(Query);
            _RefreshCommand = new DelegateCommand(Refresh);
            _ResetCommand = new DelegateCommand(Reset);
        }

        private Stack<dynamic> MethodName;

        private void Query(object parameter)
        {
            try
            {
                //BaseViewModelCollection>.QuerySingle<IC>
                if (parameter is ObjectDataProvider)
                {

                    ObjectDataProvider provider = (ObjectDataProvider)parameter;

                    if (provider != null)
                    {
                        if (MethodName.Count == 0)
                            MethodName.Push(new { MethodName = provider.MethodName, Parameters = provider.MethodParameters });

                        provider.MethodName = "QueryByText";

                        if (provider.MethodParameters.Count == 0)
                            provider.MethodParameters.Add(SearchText);
                        else
                        {
                            if (provider.MethodParameters.Count > 1)
                            {
                                provider.MethodParameters.Clear();
                                provider.MethodParameters.Add(SearchText);
                            }
                            else
                            {
                                provider.MethodParameters[0] = SearchText;
                            }
                        }
                        provider.Refresh();
                    }


                }

            }
            catch (Exception)
            {

            }

        }

        private void Refresh(object parameter)
        {
            try
            {
                //BaseViewModelCollection>.QuerySingle<IC>
                if (parameter is ObjectDataProvider)
                {

                    ObjectDataProvider provider = (ObjectDataProvider)parameter;

                    if (provider != null)
                    {
                        provider.MethodName = "QueryByText";

                        if (provider.MethodParameters.Count == 0)
                            provider.MethodParameters.Add(SearchText);
                        else
                        {
                            if (provider.MethodParameters.Count > 1)
                            {
                                provider.MethodParameters.Clear();
                                provider.MethodParameters.Add(SearchText);
                            }
                            else
                            {
                                provider.MethodParameters[0] = SearchText;
                            }
                        }
                        provider.Refresh();
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void Reset(object parameter)
        {
            try
            {
                if (parameter is ObjectDataProvider)
                {

                    ObjectDataProvider provider = (ObjectDataProvider)parameter;

                    if (provider != null)
                    {
                        if (MethodName.Count > 0)
                        {
                            var laststack = MethodName.Pop();

                            provider.MethodName = laststack.MethodName;
                            provider.MethodParameters.Clear();
                            foreach (var item in laststack.Parameters)
                            {
                                provider.MethodParameters.Add(item);
                            }
                        }


                        provider.Refresh();
                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private string _SearchText = string.Empty;
        public string SearchText { get => _SearchText; set { _SearchText = value; OnPropertyChanged("SearchText"); } }

        private ICommand _QueryCommand;
        public ICommand QueryCommand { get => _QueryCommand; set => _QueryCommand = value; }
        private ICommand _RefreshCommand = null;
        public ICommand RefreshCommand { get => _RefreshCommand; set => _RefreshCommand = value; }
        private ICommand _ResetCommand;
        public ICommand ResetCommand { get => _ResetCommand; set => _ResetCommand = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string Name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }


    }
}
