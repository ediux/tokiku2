using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class RecvMaterialDetailsViewModelCollection : BaseViewModelCollection<RecvMaterialDetailsViewModel>
    {

        public RecvMaterialDetailsViewModelCollection()
        {

        }

        public RecvMaterialDetailsViewModelCollection(IEnumerable<RecvMaterialDetailsViewModel> source) : base(source)
        {

        }

        public static RecvMaterialDetailsViewModelCollection Query(Guid ProjectId,Guid MasterId)
        {
            try
            {
                return Query<RecvMaterialDetailsViewModelCollection, Entity.ReceiveDetails>("RecvMaterial", "Query", ProjectId, MasterId);
            }
            catch (Exception ex)
            {
                RecvMaterialDetailsViewModelCollection emptycollection = new RecvMaterialDetailsViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
        }
    }
}
