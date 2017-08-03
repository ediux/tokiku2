using System;
using System.Collections.Generic;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public interface IRequiredController : IBaseController<Required>
    {
        IExecuteResultEntity<Required> CreateNew(string ProjectShortName);
        IExecuteResultEntity<ICollection<Required>> Query();
        IExecuteResultEntity<ICollection<RequiredDetails>> QueryAllDetail(Guid RequiredId);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetail(Guid RequiredId);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByCode(Guid ProjectId, Guid RequiredDetailId, string Code);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByCode(string Code);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByFactoryNumber(Guid ProjectId, Guid RequiredDetailId, string FactoryNumber);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByFactoryNumber(string TokikuId, string FactoryNumber);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByMaterial(Guid ProjectId, Guid RequiredDetailId, string Material);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByMaterial(string Material);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByMaterial(string TokikuId, string ManufacturersId, string Material);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByOrderLength(Guid ProjectId, Guid RequiredDetailId, decimal OrderLength);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByUnitPrice(string Material, float? UnitPrice);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByUnitWeight(decimal Weight);
        IExecuteResultEntity<RequiredDetails> QuerySingleDetailByUnitWeight(Guid ProjectId, Guid RequiredDetailId, decimal Weight);
    }
}