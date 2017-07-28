using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace Tokiku.ViewModels.Base
{
    public class CommandObjectDataProvider : ObjectDataProvider
    {
        public CommandObjectDataProvider()
        {
            
            //if (Data != null)
            //{
            //    var viewmodellist = ObjectType.GetInterfaces().OfType<IBaseViewModel>();
            //    if (viewmodellist.Any())
            //    {

            //    }

            //}
        }

        //protected override void BeginQuery()
        //{
        //    base.BeginQuery();
        //}

        //protected override void OnQueryFinished(object newData, Exception error, DispatcherOperationCallback completionWork, object callbackArguments)
        //{
        //    if (newData != null && (newData is IBaseViewModel || newData is ISingleBaseViewModel))
        //    {
        //        if (newData is IBaseViewModel)
        //        {
        //            _QueryCommand = ((IBaseViewModel)newData).QueryCommand;
        //        }
        //    }
            
        //    base.OnQueryFinished(newData, error, completionWork, callbackArguments);
        //}

        private ICommand _QueryCommand;
        public ICommand QueryCommand { get => _QueryCommand; set => _QueryCommand = value; }
    }
}
