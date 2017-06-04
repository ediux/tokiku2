using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class PromissoryNoteManagementRepository : EFRepository<PromissoryNoteManagement>, IPromissoryNoteManagementRepository
	{

	}

	public  partial interface IPromissoryNoteManagementRepository : IRepositoryBase<PromissoryNoteManagement>
	{

	}
}