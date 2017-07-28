﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class RecvMaterialController : BaseController<Receive>
    {
        private ExecuteResultEntity<ICollection<Receive>> rtn;

        public ExecuteResultEntity<Receive> QuerySingle(Guid ProjectId, Guid Id)
        {
            try
            {
                var repo = this.GetRepository();

                var result = from q in repo.All()
                             from s in q.ReceiptDetails
                             where s.OrderDetails.RequiredDetails.Required.ProjectId == ProjectId
                             && q.Id == Id
                             select s.Receipts;

                return ExecuteResultEntity<Receive>.CreateResultEntity(
                    result.SingleOrDefault());
            }
            catch (Exception ex)
            {
                var rtn = ExecuteResultEntity<Receive>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

        public ExecuteResultEntity<ICollection<ReceiveDetails>> Query(Guid ProjectId, Guid Id)
        {
            try
            {
                var repo = this.GetRepository<ReceiveDetails>();

                var result = from q in repo.All()
                             where q.OrderDetails.RequiredDetails.Required.ProjectId == ProjectId
                             && q.Receipts.Id == Id
                             select q;

                return ExecuteResultEntity<ICollection<ReceiveDetails>>.CreateResultEntity(
                    new Collection<ReceiveDetails>(result.ToList()));
            }
            catch (Exception ex)
            {
                var rtn = ExecuteResultEntity<ICollection<ReceiveDetails>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
        public ExecuteResultEntity<ICollection<Receive>> QuerAll()
        {
            try
            {
                var repo = RepositoryHelper.GetReceiveRepository();
                return ExecuteResultEntity<ICollection<Receive>>.CreateResultEntity(
                    new Collection<Receive>(repo.All().ToList()));
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<Receive>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
