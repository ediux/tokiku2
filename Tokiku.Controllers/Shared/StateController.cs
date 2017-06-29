﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class StateController : BaseController<States>
    {
        public Task<ExecuteResultEntity<ICollection<States>>> GetStateListAsync()
        {
            try
            {
                StatesRepository repo = RepositoryHelper.GetStatesRepository();
                return Task.FromResult(ExecuteResultEntity<ICollection<States>>.CreateResultEntity(new Collection<States>(repo.All().ToList())));

            }
            catch (Exception ex)
            {
                return Task.FromResult(ExecuteResultEntity<ICollection<States>>.CreateErrorResultEntity(ex));
                throw;
            }
        }
    }
}
