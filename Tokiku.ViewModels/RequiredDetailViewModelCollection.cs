﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class RequiredDetailViewModelCollection : BaseViewModelCollection<RequiredDetailViewModel>
    {
        public RequiredDetailViewModelCollection()
        {

        }

        public RequiredDetailViewModelCollection(IEnumerable<RequiredDetailViewModel> source):base(source)
        {

        }

        public static RequiredDetailViewModelCollection Query(Guid RequireId)
        {
            try
            {
                return Query<RequiredDetailViewModelCollection, RequiredDetails>(
                    "Required", "QueryAllDetail", RequireId);
            }
            catch (Exception ex)
            {
                RequiredDetailViewModelCollection collection = new RequiredDetailViewModelCollection();
                setErrortoModel(collection, ex);
                return collection;
            }
        }
    }
}
