using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    /// <summary>
    /// �u�{���ت��x�s�w
    /// </summary>
    public partial class EngineeringRepository : EFRepository<Engineering>, IEngineeringRepository
    {

    }

    /// <summary>
    /// �u�{���ت��x�s�w
    /// </summary>
	public partial interface IEngineeringRepository : IRepositoryBase<Engineering>
    {

    }
}