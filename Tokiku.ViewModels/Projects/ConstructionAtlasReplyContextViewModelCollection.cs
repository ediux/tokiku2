using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class ConstructionAtlasReplyContextViewModelCollection : BaseViewModelCollection<ConstructionAtlasReplyContextViewModel>
    {
        public override void Initialized()
        {
            base.Initialized();
            Add(new ConstructionAtlasReplyContextViewModel()
            {
                Value = 1,
                Text = "存查"
            });
            Add(new ConstructionAtlasReplyContextViewModel()
            {
                Value = 2,
                Text = "同意"
            });
            Add(new ConstructionAtlasReplyContextViewModel()
            {
                Value = 3,
                Text = "修正後同意"
            });
            Add(new ConstructionAtlasReplyContextViewModel()
            {
                Value = 4,
                Text = "修正後送審"
            });
            Add(new ConstructionAtlasReplyContextViewModel()
            {
                Value = 5,
                Text = "退件重新送審"
            });
            Add(new ConstructionAtlasReplyContextViewModel()
            {
                Value = 6,
                Text = "其他:輸入文字"
            });
        }
    }
}
