using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            _LoginedUser = new Users()
            {
                UserId = Guid.Empty,
                UserName = "root",
                LoweredUserName = "root",
                IsAnonymous = false,
            };
        }
        private Users _LoginedUser;

        private ProjectBaseViewModel _selectedProjectData = null;

        private Collection<ProjectBaseViewModel> _selectList = new Collection<ProjectBaseViewModel>();

        /// <summary>
        /// 目前選定的專案
        /// </summary>
        public ProjectBaseViewModel CurrentProject
        {
            get
            {
                //if (_selectedProjectData == null)
                //{
                //    return "專案";
                //}
                //else
                //{
                //    return string.Format("{0} - {1}", _selectedProjectData?.Code ?? "", _selectedProjectData?.ShortName ?? "");
                //}
                return _selectedProjectData;
            }

            set
            {
                _selectedProjectData = value;

                RaisePropertyChanged("CurrentProject");
            }
        }

        public Users LoginedUser
        {
            get { return _LoginedUser; }
            set
            {
                _LoginedUser = value;
                RaisePropertyChanged("LoginedUser");
            }
        }
    }
}
