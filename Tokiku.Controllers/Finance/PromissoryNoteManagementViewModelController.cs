using System;
using System.Collections.Generic;
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
            sql = " select c.ContractNumber as 工程代號, d.Name as 專案名稱, " +
                         " x.票據類型代號, x.票據名稱, x.金額, x.開立日期, x.取回日期, " +
                         " z.票據類型代號, z.票據名稱, z.金額, z.開立日期, z.取回日期 " +
                    " from (select ProjectContractId, b.Id as 票據類型代號, b.Name as 票據名稱, " +
                                 " Amount as 金額, OpenDate as 開立日期, RecoveryDate as 取回日期 " +
                            " from PromissoryNoteManagement a " +
                       " left join TicketTypes b on b.Id = a.TicketTypeId " +
                           " where b.IsPromissoryNote = 0) x " +
               " left join (select ProjectContractId, b.Id as 票據類型代號, b.Name as 票據名稱, " +
                                 " Amount as 金額, OpenDate as 開立日期, RecoveryDate as 取回日期 " +
                            " from PromissoryNoteManagement a " +
                       " left join TicketTypes b on b.Id = a.TicketTypeId " +
                           " where b.IsPromissoryNote = 1) z on z.ProjectContractId = x.ProjectContractId " +
               " left join ProjectContract c on c.Id = x.ProjectContractId " +
               " left join Projects d on c.ProjectId = d.Id ";

            return null;
        }

    }
}
