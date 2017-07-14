using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class StatesViewModelCollection : BaseViewModelCollection<StatesViewModel>
    {


        public StatesViewModelCollection()
        {

        }

        public StatesViewModelCollection(IEnumerable<StatesViewModel> source) : base(source)
        {

        }

        //public override void Initialized()
        //{
        //    base.Initialized();
        //    controller = new Controllers.StateController();
        //    //Query();
        //}
        public static StatesViewModelCollection Query()
        {
            return Query<StatesViewModelCollection, States>("State", "QueryAll");
        }
        //public async override void Query()
        //{
        //    var result = await controller.GetStateListAsync();

        //    if (!result.HasError)
        //    {
        //        if (result.Result.Any())
        //        {
        //            ClearItems();
        //            foreach (var item in result.Result)
        //            {
        //                StatesViewModel model = new StatesViewModel();
        //                model.SetModel(item);
        //                Add(model);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Errors = result.Errors;
        //        HasError = result.HasError;
        //    }
        //}

    }
    public class StatesViewModel : BaseViewModelWithPOCOClass<States>
    {
        public StatesViewModel()
        {

        }

        public StatesViewModel(States entity) : base(entity)
        {

        }

        public new byte Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }



        public string StateName
        {
            get { return CopyofPOCOInstance.StateName; }
            set { CopyofPOCOInstance.StateName = value; RaisePropertyChanged("StateName"); }
        }


        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        States data = (States)entity;
        //        BindingFromModel(data, this);
        //    }
        //    catch (Exception ex)
        //    {

        //        setErrortoModel(this, ex);
        //    }
        //}

        public override string ToString()
        {
            return this.StateName;
        }
    }
}
