using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    /// <summary>
    /// 工程項目的儲存庫
    /// </summary>
    public partial class EngineeringRepository : EFRepository<Engineering>, IEngineeringRepository
    {

    }

    /// <summary>
    /// 工程項目的儲存庫
    /// </summary>
	public partial interface IEngineeringRepository : IRepositoryBase<Engineering>
    {

    }
}