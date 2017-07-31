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
    public class OrdersController : BaseController<Orders>
    {
        #region Orders
        public ExecuteResultEntity<Orders> CreateNew(Guid ProjectId, Guid ManufacturerId = default(Guid))
        {
            ExecuteResultEntity<Orders> rtn;

            try
            {
                var repo = this.GetRepository<OrderDetails>();
                var result = (from q in repo.All()
                              where q.RequiredDetails.Required.ProjectId == ProjectId
                              && q.Orders.FormNumber.Contains(string.Format("{0}-{1}-O", q.RequiredDetails.Required.Projects.ShortName, q.Orders.Manufacturers.ShortName))
                              orderby q.RequiredDetails.Required.Projects.Code descending
                              select q).Distinct();

                if (result.Count() > 0)
                {
                    int nextSerialNumber = 0;
                    int counters = 0;

                    var data = result.First();
                    int.TryParse(data.Orders.FormNumber.Replace(string.Format("{0}-{1}-O", data.RequiredDetails.Required.Projects.ShortName, data.Orders.Manufacturers.ShortName), ""), out nextSerialNumber);

                    nextSerialNumber += 1;
                    var lastrow = result.FirstOrDefault();
                    Orders newitem = new Orders();
                    newitem.Id = Guid.NewGuid();
                    newitem.Manufacturers = new Manufacturers();

                    string formnumber = string.Format("{0}-{1}-O-{2:000}",
                        lastrow?.RequiredDetails?.Required?.Projects?.ShortName,
                        lastrow.RequiredDetails.Required.Manufacturers.ShortName,
                        nextSerialNumber);

                    var result2 = (from q in repo.All()
                                   where q.RequiredDetails.Required.ProjectId == ProjectId
                                   && q.Orders.FormNumber.Contains(formnumber)
                                   orderby q.RequiredDetails.Required.Projects.Code descending
                                   select q).Distinct();

                    counters = result2.Count() + 1;

                    formnumber = string.Format("{0}-{1}", formnumber, counters);
                    newitem.FormNumber = formnumber;
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
                    var projectrepo = this.GetRepository<Projects>();
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
                    newitem.FormNumber = string.Format("{0}-{0}-O-001", findproject.ShortName);
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

        public ExecuteResultEntity<ICollection<Orders>> QueryBy(string OrderFormNumber)
        {
            ExecuteResultEntity<ICollection<Orders>> rtn;

            try
            {
                var repo = this.GetRepository();

                var result = (from q in repo.All()
                              where q.FormNumber == OrderFormNumber
                              orderby q.FormNumber descending
                              select q).Distinct();

                return ExecuteResultEntity<ICollection<Orders>>.CreateResultEntity(new Collection<Orders>(result.ToList()));
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<Orders>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
        public ExecuteResultEntity<ICollection<Orders>> Query(Guid ProjectId)
        {
            ExecuteResultEntity<ICollection<Orders>> rtn;

            try
            {
                var repo = this.GetRepository<OrderDetails>();

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




    }

    public class OrderDetailsController : BaseController<OrderDetails>
    {
        #region Order Details
        public ExecuteResultEntity<OrderDetails> QuerySingleDetailByCode(string code)
        {
            ExecuteResultEntity<OrderDetails> rtn;

            try
            {
                var repo = this.GetRepository<OrderDetails>();
                var result = (from q in repo.All()
                              from p in q.RequiredDetails.Required.Projects.Required
                              from m in p.RequiredDetails
                              from x in m.OrderDetails
                              where m.Code == code
                              orderby q.RequiredDetails.Required.Projects.Code descending
                              select x).Distinct();


                return ExecuteResultEntity<OrderDetails>.CreateResultEntity(result.FirstOrDefault());
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<OrderDetails>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }


        public ExecuteResultEntity<OrderDetails> QuerySingleDetailByReturnDetail(
            string OrderFormNumber,
            string BatchNumber,
            string Code,
            string FactoryNumber,
            string MaterialsName)
        {
            ExecuteResultEntity<OrderDetails> rtn;

            try
            {
                var repo = this.GetRepository<OrderDetails>();
                var result = (from q in repo.All()
                              from p in q.RequiredDetails.Required.Projects.Required
                              from m in p.RequiredDetails
                              from x in m.OrderDetails
                              where x.Orders.FormNumber == OrderFormNumber
                              && x.Orders.BatchNumber == BatchNumber
                              && m.Code == Code
                              && m.FactoryNumber == FactoryNumber
                              && m.Materials.Name == MaterialsName                              
                              orderby q.RequiredDetails.Required.Projects.Code descending
                              select x).Distinct();


                return ExecuteResultEntity<OrderDetails>.CreateResultEntity(result.FirstOrDefault());
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<OrderDetails>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
        #endregion
    }

    public class OrderTypesController : BaseController<OrderTypes>
    {
       
        #region OrderTypes
        public ExecuteResultEntity<ICollection<OrderTypes>> Query()
        {
            try
            {
                var repo = this.GetRepository<OrderTypes>();

                return ExecuteResultEntity<ICollection<OrderTypes>>.CreateResultEntity(
                    new Collection<OrderTypes>(repo.All().ToList()));
            }
            catch (Exception ex)
            {
                var rtn = ExecuteResultEntity<ICollection<OrderTypes>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
        #endregion
    }
}
