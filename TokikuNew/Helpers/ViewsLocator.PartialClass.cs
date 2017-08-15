using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.DataServices;
using Tokiku.Entity;
using Tokiku.MVVM;
using Tokiku.ViewModels;

namespace TokikuNew
{
    public partial class ViewsLocator
    {
        partial void RunOthersRegister()
        {
            _StartUpLocator = new StartUpLocator();
            _EntityLocator = new EntityLocator();
            _DataServiceLocator = new DefaultLocator();
            _ViewModelLocator = new ViewModelLocator();
        }

        private StartUpLocator _StartUpLocator;

        public StartUpLocator StartUpLocator { get => _StartUpLocator; }

        private ViewModelLocator _ViewModelLocator;

        public ViewModelLocator ViewModelLocator { get => _ViewModelLocator; }

        private EntityLocator _EntityLocator;

        public EntityLocator EntityLocator { get => _EntityLocator; }

        private DefaultLocator _DataServiceLocator;

        public DefaultLocator DataServiceLocator { get => _DataServiceLocator; }
    }
}
