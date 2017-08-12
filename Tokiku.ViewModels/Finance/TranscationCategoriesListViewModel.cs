using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TranscationCategoriesListViewModel : DocumentBaseViewModel, ITranscationCategoriesListViewModel
    {
        private IFinancialManagementDataService _FinancialManagementDataService;
        public TranscationCategoriesListViewModel(IFinancialManagementDataService FinancialManagementDataService,
            ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;
        }

        public ObservableCollection<ITranscationCategoriesViewModel> TranscationCategories { get; set; }

    }
}
