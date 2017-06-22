using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ProcessingAtlasController : BaseController<ProcessingAtlas>
    {
        public override ExecuteResultEntity<ProcessingAtlas> CreateNew()
        {
            try
            {
                ProcessingAtlas entity = new ProcessingAtlas();
                entity.Id = Guid.NewGuid();
                entity.CreateTime = DateTime.Now;
                entity.CreateUserId = GetCurrentLoginUser().Result.UserId;
                return ExecuteResultEntity<ProcessingAtlas>.CreateResultEntity(entity);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ProcessingAtlas>.CreateErrorResultEntity(ex);

            }

        }

        public ExecuteResultEntity<ProcessingAtlasDetailEntity> GetProcessAtlasUpdateInformation(ProcessingAtlas data)
        {
            try
            {
                var accesslogrepo = RepositoryHelper.GetAccessLogRepository();
                var procdatarepo = RepositoryHelper.GetProcessingAtlasRepository(accesslogrepo.UnitOfWork);
                string ID = data.Id.ToString("N");

                var queryupdatecount = (from q in accesslogrepo.All()
                                        where q.ActionCode == (int)ActionCodes.Update && q.DataId == ID 
                                        orderby q.CreateTime descending
                                        select q).ToList();

                var querylastupdate = (from q in accesslogrepo.All()
                                       where q.ActionCode == (int)ActionCodes.ConstructionOrderChange && q.DataId == ID
                                       orderby q.CreateTime descending
                                       select q).FirstOrDefault();

                ProcessingAtlasDetailEntity entity = new ProcessingAtlasDetailEntity();
                entity.ConstructionOrderChangeDate = querylastupdate != null ? querylastupdate.CreateTime : data.CreateTime;
                var lastupdate = queryupdatecount.FirstOrDefault();
                entity.LastUpdate = lastupdate != null ? lastupdate.CreateTime : data.CreateTime;
                entity.UpdateTimes = queryupdatecount.Count;

                return ExecuteResultEntity<ProcessingAtlasDetailEntity>.CreateResultEntity(entity);

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ProcessingAtlasDetailEntity>.CreateErrorResultEntity(ex);
            }
        }
    }
}
