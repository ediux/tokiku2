using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class OrdersController : BaseController<Orders>, IBaseController<OrderDetails>, IBaseController<OrderTypes>
    {
        #region Orders
        public ExecuteResultEntity<Orders> CreateNew(Guid ProjectId)
        {
            ExecuteResultEntity<Orders> rtn;

            try
            {
                var repo = this.GetReoisitory<OrderDetails>();
                var result = (from q in repo.All()
                              where q.RequiredDetails.Required.ProjectId == ProjectId
                              orderby q.RequiredDetails.Required.Projects.Code descending
                              select q).Distinct();

                if (result.Count() > 0)
                {
                    int nextSerialNumber = 0;

                    int.TryParse(result.First().Orders.FormNumber.Replace(result.First().RequiredDetails.Required.Projects.ShortName, ""), out nextSerialNumber);

                    nextSerialNumber += 1;
                    var lastrow = result.FirstOrDefault();
                    Orders newitem = new Orders();
                    newitem.Id = Guid.NewGuid();
                    newitem.Manufacturers = new Manufacturers();
                    newitem.FormNumber = string.Format("{0}-{1}-O-{2:000}-{3}", lastrow?.RequiredDetails.Required.Projects.ShortName, lastrow.RequiredDetails.Required.Manufacturers.ShortName, nextSerialNumber);
                    newitem.CreateTime = DateTime.Now;
                    newitem.MakingTime = DateTime.Now;

                    newitem.CreateUsers = GetCurrentLoginUser().Result;
                    newitem.CreateUserId = newitem.CreateUsers.UserId;
                    newitem.MakingUsers = newitem.CreateUsers;
                    newitem.MakingUserId = newitem.MakingUsers.UserId;

                    return ExecuteResultEntity<Orders>.CreateResultEntity(newitem);
                }
                else
                {
                    var projectrepo = this.GetReoisitory<Projects>();
                    var findproject = (from q in projectrepo.All()
                                       where q.Id == ProjectId
                                       select q).SingleOrDefault();

                    if (findproject == null)
                    {
                        return ExecuteResultEntity<Orders>.CreateErrorResultEntity("無法找到專案!");
                    }

                    Orders newitem = new Orders();
                    newitem.Id = Guid.NewGuid();
                    newitem.Manufacturers = new Manufacturers();
                    newitem.FormNumber = string.Format("{0}001", findproject.ShortName);
                    newitem.CreateTime = DateTime.Now;
                    newitem.MakingTime = DateTime.Now;

                    newitem.CreateUsers = GetCurrentLoginUser().Result;
                    newitem.CreateUserId = newitem.CreateUsers.UserId;
                    newitem.MakingUsers = newitem.CreateUsers;
                    newitem.MakingUserId = newitem.MakingUsers.UserId;
                    return ExecuteResultEntity<Orders>.CreateResultEntity(newitem);
                }
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<Orders>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

        public ExecuteResultEntity<ICollection<Orders>> Query(Guid ProjectId)
        {
            ExecuteResultEntity<ICollection<Orders>> rtn;

            try
            {
                var repo = this.GetReoisitory<OrderDetails>();

                var result = (from q in repo.All()
                              where q.RequiredDetails.Required.ProjectId == ProjectId
                              orderby q.RequiredDetails.Required.Projects.Code descending
                              select q.Orders).Distinct();

                return ExecuteResultEntity<ICollection<Orders>>.CreateResultEntity(new Collection<Orders>(result.ToList()));
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<Orders>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
        #endregion

        #region Order Details
        public ExecuteResultEntity Add(OrderDetails entity, bool isLastRecord = true)
        {
            throw new NotImplementedException();
        }



        public ExecuteResultEntity<OrderDetails> CreateOrUpdate(OrderDetails entity, bool isLastRecord = true)
        {
            throw new NotImplementedException();
        }



        public ExecuteResultEntity<OrderDetails> Delete(OrderDetails entity, bool isDeleteRightNow = false)
        {
            throw new NotImplementedException();
        }



        public bool IsExists(Expression<Func<OrderDetails, bool>> filiter)
        {
            throw new NotImplementedException();
        }


        public ExecuteResultEntity<ICollection<OrderDetails>> Query(Expression<Func<OrderDetails, bool>> filiter)
        {
            throw new NotImplementedException();
        }



        public ExecuteResultEntity<OrderDetails> Update(OrderDetails fromModel, bool isLastRecord = true)
        {
            throw new NotImplementedException();
        }



        ExecuteResultEntity<OrderDetails> IBaseController<OrderDetails>.CreateNew()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region OrderTypes
        public ExecuteResultEntity Add(OrderTypes entity, bool isLastRecord = true)
        {
            throw new NotImplementedException();
        }

        public ExecuteResultEntity<OrderTypes> CreateOrUpdate(OrderTypes entity, bool isLastRecord = true)
        {
            throw new NotImplementedException();
        }
        public ExecuteResultEntity<OrderTypes> Delete(OrderTypes entity, bool isDeleteRightNow = false)
        {
            throw new NotImplementedException();
        }
        public bool IsExists(Expression<Func<OrderTypes, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public ExecuteResultEntity<ICollection<OrderTypes>> Query(Expression<Func<OrderTypes, bool>> filiter)
        {
            throw new NotImplementedException();
        }

        public ExecuteResultEntity<ICollection<OrderTypes>> Query()
        {
            try
            {
                var repo = this.GetReoisitory<OrderTypes>();

                return ExecuteResultEntity<ICollection<OrderTypes>>.CreateResultEntity(
                    new Collection<OrderTypes>(repo.All().ToList()));
            }
            catch (Exception ex)
            {
                var rtn = ExecuteResultEntity<ICollection<OrderTypes>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }

        public ExecuteResultEntity<OrderTypes> Update(OrderTypes fromModel, bool isLastRecord = true)
        {
            throw new NotImplementedException();
        }

        ExecuteResultEntity<OrderTypes> IBaseController<OrderTypes>.CreateNew()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
