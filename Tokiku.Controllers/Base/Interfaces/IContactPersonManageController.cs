﻿using System;
using System.Collections.Generic;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IContactPersonManageController : IBaseController<Contacts>
    {
        bool IsExists(Guid ContactId);
        IExecuteResultEntity<ICollection<Contacts>> QueryAll();
        IExecuteResultEntity<ICollection<Contacts>> SearchByText(string filiter, Guid ManufactoryId, bool isClient);
        IExecuteResultEntity Update(Contacts updatedProject, Guid UserId);
    }
}