﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.Entity.ViewTables;

namespace Tokiku.Controllers
{
    public class PromissoryNoteManagementViewModelController : BaseController
    {
        public string sql;
        
        public ExecuteResultEntity<ICollection<PromissoryNoteManagementEntity>> QuerAll()
        {
            sql = " select c.ContractNumber as ContractNumber, c.Name as ProjectName, " +
                         " x.PromissoryId, x.PromissoryName, x.PromissoryAmount, x.PromissoryOpenDate, x.PromissoryRecoveryDate, " +
                         " z.WarrantyId, z.WarrantyName, z.WarrantyAmount, z.WarrantyOpenDate, z.WarrantyRecoveryDate, " +
                         " e.UserId as CreateUserId e.UserName as CreateUser, d.CreateTime as CreateTime " +
                    " from (select ProjectContractId, b.Id as PromissoryId, b.Name as PromissoryName, " +
                                 " Amount as PromissoryAmount, OpenDate as PromissoryOpenDate, RecoveryDate as PromissoryRecoveryDate " +
                            " from PromissoryNoteManagement a " +
                       " left join TicketTypes b on b.Id = a.TicketTypeId " +
                       " left join ProjectContract c on c.Id = a.ProjectContractId " +
                           " where b.IsPromissoryNote = 0) x " +
               " left join (select ProjectContractId, b.Id as WarrantyId, b.Name as WarrantyName, " +
                                 " Amount as WarrantyAmount, OpenDate as WarrantyOpenDate, RecoveryDate as WarrantyRecoveryDate " +
                            " from PromissoryNoteManagement a " +
                       " left join TicketTypes b on b.Id = a.TicketTypeId " +
                       " left join ProjectContract c on c.Id = a.ProjectContractId " +
                           " where b.IsPromissoryNote = 1) z on z.ProjectContractId = x.ProjectContractId " + // 專案合約代碼需相同
               " left join ProjectContract c on c.Id = x.ProjectContractId " +
               " left join Projects d on d.Id = c.ProjectId " +
               " left join Users e on c.CreateUserId = e.UserId ";

            ExecuteResultEntity<ICollection<PromissoryNoteManagementEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<PromissoryNoteManagementEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<PromissoryNoteManagementEntity>>.CreateResultEntity(
                        new Collection<PromissoryNoteManagementEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<PromissoryNoteManagementEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }

        }

    }
}
