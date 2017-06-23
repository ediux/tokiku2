using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class BOMViewModelCollection : BaseViewModelCollection<BOMViewModel>
    {
        public BOMViewModelCollection():base()
        {

        }
        public BOMViewModelCollection(IEnumerable<BOMViewModel> source):base(source)
        {

        }

        public override void Query()
        {
            try
            {

            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        public override void SaveModel()
        {
            try
            {

            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
