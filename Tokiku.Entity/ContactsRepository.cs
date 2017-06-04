using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class ContactsRepository : EFRepository<Contacts>, IContactsRepository
	{

	}

	public  partial interface IContactsRepository : IRepositoryBase<Contacts>
	{

	}
}