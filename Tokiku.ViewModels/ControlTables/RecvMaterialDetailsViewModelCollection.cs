﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public class RecvMaterialDetailsViewModelCollection : BaseViewModelCollection<RecvMaterialDetailsViewModel, ReceiveDetails>
    {

        public RecvMaterialDetailsViewModelCollection()
        {

        }

        public RecvMaterialDetailsViewModelCollection(IEnumerable<RecvMaterialDetailsViewModel> source) : base(source)
        {

        }

        public static RecvMaterialDetailsViewModelCollection Query(Guid ProjectId, Guid MasterId)
        {
            try
            {
                return Query<RecvMaterialDetailsViewModelCollection>("RecvMaterial", "Query", ProjectId, MasterId);
            }
            catch (Exception ex)
            {
                RecvMaterialDetailsViewModelCollection emptycollection = new RecvMaterialDetailsViewModelCollection();
                emptycollection.setErrortoModel(ex);
                return emptycollection;
            }
        }
    }
}
