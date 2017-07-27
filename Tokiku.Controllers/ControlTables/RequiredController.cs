using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class RequiredController : BaseController<Required>
    {
        #region 表頭建立
        /// <summary>
        /// 建立需求單表頭項目
        /// </summary>
        /// <param name="ProjectShortName"></param>
        /// <returns></returns>
        public ExecuteResultEntity<Required> CreateNew(string ProjectShortName)
        {
            ExecuteResultEntity<Required> rtn;

            try
            {
                var repo = this.GetReoisitory();
                var result = from q in repo.All()
                             where q.Projects.ShortName == ProjectShortName
                             orderby q.FormNumber descending
                             select q;

                if (result.Count() > 0)
                {
                    int nextSerialNumber = 0;

                    int.TryParse(result.First().FormNumber.Replace(ProjectShortName, ""), out nextSerialNumber);

                    nextSerialNumber += 1;

                    Required newitem = new Required();
                    newitem.Id = Guid.NewGuid();
                    newitem.Projects = result.FirstOrDefault()?.Projects;
                    newitem.Manufacturers = new Manufacturers();
                    newitem.FormNumber = string.Format("{0}{1:000}", ProjectShortName, nextSerialNumber);
                    newitem.CreateTime = DateTime.Now;
                    newitem.MakingTime = DateTime.Now;

                    newitem.CreateUser = GetCurrentLoginUser().Result;
                    newitem.CreateUserId = newitem.CreateUser.UserId;
                    newitem.MakingUser = newitem.CreateUser;
                    newitem.MakingUserId = newitem.MakingUser.UserId;

                    return ExecuteResultEntity<Required>.CreateResultEntity(newitem);
                }
                else
                {
                    var projectrepo = this.GetReoisitory<Projects>();
                    var findproject = (from q in projectrepo.All()
                                       where q.ShortName == ProjectShortName
                                       select q).SingleOrDefault();

                    if (findproject == null)
                    {
                        return ExecuteResultEntity<Required>.CreateErrorResultEntity("無法找到專案!");
                    }

                    Required newitem = new Required();
                    newitem.Id = Guid.NewGuid();
                    newitem.Projects = findproject;
                    newitem.ProjectId = findproject.Id;
                    newitem.Manufacturers = new Manufacturers();
                    newitem.FormNumber = string.Format("{0}001", ProjectShortName);
                    newitem.CreateTime = DateTime.Now;
                    newitem.MakingTime = DateTime.Now;

                    newitem.CreateUser = GetCurrentLoginUser().Result;
                    newitem.CreateUserId = newitem.CreateUser.UserId;
                    newitem.MakingUser = newitem.CreateUser;
                    newitem.MakingUserId = newitem.MakingUser.UserId;
                    return ExecuteResultEntity<Required>.CreateResultEntity(newitem);
                }
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<Required>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
        #endregion

        #region 表頭查詢
        /// <summary>
        /// 查詢需求單列表
        /// </summary>
        /// <returns></returns>
        public ExecuteResultEntity<ICollection<Required>> Query()
        {
            ExecuteResultEntity<ICollection<Required>> rtn;

            try
            {
                var repo = RepositoryHelper.GetRequiredRepository();
                return ExecuteResultEntity<ICollection<Required>>.CreateResultEntity(
                    new Collection<Required>(repo.All().ToList()));
            }
            catch (Exception ex)
            {
                rtn = ExecuteResultEntity<ICollection<Required>>.CreateErrorResultEntity(ex);
                return rtn;
            }
        }
        #endregion

        #region 表身內容查詢
        /// <summary>
        /// 查詢需求單細項列表
        /// </summary>
        /// <param name="RequiredId"></param>
        /// <returns></returns>
        public ExecuteResultEntity<ICollection<RequiredDetails>> QueryAllDetail(Guid RequiredId)
        {
            try
            {
                if (RequiredId == Guid.Empty)
                {
                    return ExecuteResultEntity<ICollection<RequiredDetails>>.CreateResultEntity(
                        new Collection<RequiredDetails>());
                }
                else
                {
                    var repo = this.GetReoisitory<RequiredDetails>().All();
                    var result = from q in repo
                                 where q.RequiredId == RequiredId
                                 select q;

                    return ExecuteResultEntity<ICollection<RequiredDetails>>.CreateResultEntity(
                        new Collection<RequiredDetails>(
                            result.ToList()));

                }
            }
            catch (Exception ex)
            {

                return ExecuteResultEntity<ICollection<RequiredDetails>>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 查詢某張需求單的東菊編號對應的需求細項
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="RequiredDetailId"></param>
        /// <param name="Code">要查詢的東菊編號</param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByCode(Guid ProjectId, Guid RequiredDetailId, string Code)
        {
            try
            {
                if (string.IsNullOrEmpty(Code))
                {
                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        new RequiredDetails());
                }
                else
                {
                    var repo = this.GetReoisitory<RequiredDetails>().All();

                    var result = from q in repo
                                 from s in q.Required.RequiredDetails
                                 where q.Required.ProjectId == ProjectId
                                 && q.Id == RequiredDetailId
                                 && s.Code == Code
                                 select s;

                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        result.SingleOrDefault());

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 查詢指定需求單細項
        /// </summary>
        /// <param name="RequiredId"></param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetail(Guid RequiredId)
        {
            try
            {
                if (RequiredId == Guid.Empty)
                {
                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        new RequiredDetails());
                }
                else
                {
                    var repo = this.GetReoisitory<RequiredDetails>().All();

                    var result = from q in repo
                                 where q.Id == RequiredId
                                 select q;

                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        result.SingleOrDefault());

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="RequiredId"></param>
        /// <param name="FactoryNumber"></param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByFactoryNumber(Guid ProjectId, Guid RequiredDetailId, string FactoryNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(FactoryNumber))
                {
                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        new RequiredDetails());
                }
                else
                {
                    var repo = this.GetReoisitory<RequiredDetails>().All();

                    var result = from q in repo
                                 from s in q.Required.RequiredDetails
                                 where q.Required.ProjectId == ProjectId
                                 && q.Id == RequiredDetailId
                                 && s.FactoryNumber == FactoryNumber
                                 select s;

                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        result.SingleOrDefault());

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="RequiredId"></param>
        /// <param name="FactoryNumber"></param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByFactoryNumber(string TokikuId, string FactoryNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(FactoryNumber))
                {
                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        new RequiredDetails());
                }
                else
                {
                    var repo = this.GetReoisitory<RequiredDetails>().All();

                    var result = from q in repo
                                 from s in q.Required.Projects.Required
                                 from m in s.RequiredDetails
                                 where m.FactoryNumber == FactoryNumber
                                 || m.Code == TokikuId
                                 orderby s.CreateTime descending
                                 select m;

                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        result.FirstOrDefault());

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="RequiredId"></param>
        /// <param name="Material"></param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByMaterial(Guid ProjectId, Guid RequiredDetailId, string Material)
        {
            try
            {
                if (string.IsNullOrEmpty(Material))
                {
                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        new RequiredDetails());
                }
                else
                {
                    var repo = this.GetReoisitory<RequiredDetails>().All();

                    var result = from q in repo
                                 from s in q.Required.RequiredDetails
                                 where q.Required.ProjectId == ProjectId
                                 && q.Id == RequiredDetailId
                                 && s.Materials.Name == Material
                                 select s;

                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        result.SingleOrDefault());

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="RequiredId"></param>
        /// <param name="Material"></param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByCode(string Code)
        {
            try
            {
                if (string.IsNullOrEmpty(Code))
                {
                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        new RequiredDetails());
                }
                else
                {
                    var repo = this.GetReoisitory<RequiredDetails>().All();

                    var result = from q in repo
                                 from p in q.Required.Projects.Required
                                 from s in p.RequiredDetails
                                 where s.Code == Code
                                 orderby p.CreateTime descending
                                 select s;

                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        result.FirstOrDefault());

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="RequiredId"></param>
        /// <param name="Material"></param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByMaterial(string TokikuId, string ManufacturersId, string Material)
        {
            try
            {
                if (string.IsNullOrEmpty(Material))
                {
                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        new RequiredDetails());
                }
                else
                {
                    var repo = this.GetReoisitory<RequiredDetails>().All();

                    var result = from q in repo
                                 from p in q.Required.Projects.Required
                                 from s in p.RequiredDetails
                                 where s.Code == TokikuId
                                 && s.FactoryNumber == ManufacturersId
                                 && s.Materials.Name == Material
                                 orderby p.CreateTime descending
                                 select s;

                    return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                        result.FirstOrDefault());

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 反查材質資料
        /// </summary>
        /// <param name="Material"></param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByMaterial(string Material)
        {
            try
            {
                var repo = this.GetReoisitory<RequiredDetails>().All();

                var result = from q in repo
                             from p in q.Required.Projects.Required
                             from s in p.RequiredDetails
                             where (s.Materials != null && s.Materials.Name == Material)
                             orderby p.CreateTime descending
                             select s;

                return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                    result.FirstOrDefault());

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByUnitPrice(string Material, float? UnitPrice)
        {
            try
            {

                var repo = this.GetReoisitory<RequiredDetails>().All();

                var result = from q in repo
                             from p in q.Required.Projects.Required
                             from s in p.RequiredDetails
                             where (s.MaterialsId != Guid.Empty && (s.Materials.Name == Material &&
                             s.Materials.UnitPrice == UnitPrice))
                             orderby p.CreateTime descending
                             select s;

                return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                    result.FirstOrDefault());

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="RequiredId"></param>
        /// <param name="Weight"></param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByUnitWeight(Guid ProjectId, Guid RequiredDetailId, decimal Weight)
        {
            try
            {

                var repo = this.GetReoisitory<RequiredDetails>().All();

                var result = from q in repo
                             from s in q.Required.RequiredDetails
                             where q.Required.ProjectId == ProjectId
                             && q.Id == RequiredDetailId
                             && s.UnitWeight == Weight
                             select s;

                return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                    result.SingleOrDefault());


            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="RequiredId"></param>
        /// <param name="Weight"></param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByUnitWeight(decimal Weight)
        {
            try
            {

                var repo = this.GetReoisitory<RequiredDetails>().All();

                var result = from q in repo
                             from s in q.Required.Projects.Required
                             from m in s.RequiredDetails
                             where m.UnitWeight == Weight
                             select m;

                return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                    result.SingleOrDefault());


            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="RequiredId"></param>
        /// <param name="OrderLength"></param>
        /// <returns></returns>
        public ExecuteResultEntity<RequiredDetails> QuerySingleDetailByOrderLength(Guid ProjectId, Guid RequiredDetailId, decimal OrderLength)
        {
            try
            {

                var repo = this.GetReoisitory<RequiredDetails>().All();

                var result = from q in repo
                             from s in q.Required.RequiredDetails
                             where q.Required.ProjectId == ProjectId
                             && q.Id == RequiredDetailId
                             && s.OrderLength == OrderLength
                             select s;

                return ExecuteResultEntity<RequiredDetails>.CreateResultEntity(
                    result.SingleOrDefault());


            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<RequiredDetails>.CreateErrorResultEntity(ex);
            }
        }
        #endregion




        //public override ExecuteResultEntity<Required> CreateOrUpdate(Required entity, bool isLastRecord = true)
        //{
        //    try
        //    {
        //        var result = base.CreateOrUpdate(entity, isLastRecord);

        //        if (!result.HasError)
        //        {
        //            ControlTableController ctrl = new ControlTableController();
        //            ctrl.Calculations(entity.Projects.Id);

        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var rtn = ExecuteResultEntity<Required>.CreateErrorResultEntity(ex);
        //        return rtn;
        //    }

        //}
    }
}
