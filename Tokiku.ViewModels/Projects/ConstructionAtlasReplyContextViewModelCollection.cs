using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class ConstructionAtlasReplyContextViewModelCollection : ObservableCollection<ConstructionAtlasReplyContextViewModel>
    {
        public ConstructionAtlasReplyContextViewModelCollection()
        {
            

        }
        public ConstructionAtlasReplyContextViewModelCollection(IEnumerable<ConstructionAtlasReplyContextViewModel> source):base(source)
        {

        }

        public static ConstructionAtlasReplyContextViewModelCollection Query()
        {
            try
            {
                ConstructionAtlasReplyContextViewModelCollection collection = new ConstructionAtlasReplyContextViewModelCollection();

                collection.Add(new ConstructionAtlasReplyContextViewModel()
                {
                    Value = 1,
                    Text = ""
                });

                collection.Add(new ConstructionAtlasReplyContextViewModel()
                {
                    Value = 2,
                    Text = "存查"
                });
                collection.Add(new ConstructionAtlasReplyContextViewModel()
                {
                    Value = 3,
                    Text = "同意"
                });
                collection.Add(new ConstructionAtlasReplyContextViewModel()
                {
                    Value = 4,
                    Text = "修正後同意"
                });
                collection.Add(new ConstructionAtlasReplyContextViewModel()
                {
                    Value = 5,
                    Text = "修正後送審"
                });
                collection.Add(new ConstructionAtlasReplyContextViewModel()
                {
                    Value = 6,
                    Text = "退件重新送審"
                });
                collection.Add(new ConstructionAtlasReplyContextViewModel()
                {
                    Value = 7,
                    Text = "其他"
                });
                return collection;
            }
            catch 
            {
                ConstructionAtlasReplyContextViewModelCollection collection = new ConstructionAtlasReplyContextViewModelCollection();
                return collection;
            }
        } 


    }
}
