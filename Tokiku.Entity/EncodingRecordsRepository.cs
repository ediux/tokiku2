using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{   
	public  partial class EncodingRecordsRepository : EFRepository<EncodingRecords>, IEncodingRecordsRepository
	{

	}

	public  partial interface IEncodingRecordsRepository : IRepositoryBase<EncodingRecords>
	{

	}
}