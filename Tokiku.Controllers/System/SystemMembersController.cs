﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class SystemMembersController : BaseController<Membership>
    {
        private string sql;

        public ExecuteResultEntity<ICollection<SystemMembersEntity>> QuerAll()
        {
            sql = " select TokikuId, ManufacturersId, Material, UnitWeight, OrderLength, " +
                         " RequiredQuantity, SparePartsQuantity, PlaceAnOrderQuantity, Note " +
                    " from TABL1 ";

            ExecuteResultEntity<ICollection<SystemMembersEntity>> rtn;

            try
            {
                using (var ManufacturersRepository = RepositoryHelper.GetManufacturersRepository())
                {
                    var queryresult = ManufacturersRepository.UnitOfWork.Context.Database.SqlQuery<SystemMembersEntity>(sql);

                    rtn = ExecuteResultEntity<ICollection<SystemMembersEntity>>.CreateResultEntity(
                        new Collection<SystemMembersEntity>(queryresult.ToList()));

                    return rtn;
                }

            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<SystemMembersEntity>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

        public ExecuteResultEntity<ICollection<Users>> Query()
        {
            try
            {
                var repo = this.GetRepository<Users>();

                return ExecuteResultEntity<ICollection<Users>>.CreateResultEntity(
                    new Collection<Users>(repo.All().ToList()));
            }
            catch (Exception ex)
            {
                var rtn = ExecuteResultEntity<ICollection<Users>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
    }
}
