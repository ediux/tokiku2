using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ControlTableController : BaseController<ControlTableDetails>
    {
        public ExecuteResultEntity<ICollection<ControlTableDetails>> Query(Guid ProjectId)
        {
            try
            {
                var repo = this.GetReoisitory().All();
                var result = from q in repo
                             where q.ControlTables.ProjectId == ProjectId
                             select q;

                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(result.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<ControlTableDetails>> SearchByText(string text)
        {
            try
            {
                if (text != null && text.Length > 0)
                {
                    //ExecuteResultEntity<ICollection<ControlTableDetails>> model = ExecuteResultEntity<ICollection<ControlTableDetails>>
                    //     .CreateResultEntity(new Collection<ControlTableDetails>(result.ToList()));

                    //return model;
                    return null;
                }
                else
                {
                    var result = QueryAll();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<ControlTableDetails>> QueryAll()
        {
            try
            {
                var repo = this.GetReoisitory();
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(repo.All().ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<ControlTableDetails>> QueryAll(Guid ProjectId)
        {
            try
            {
                if (ProjectId == Guid.Empty)
                {
                    return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                   new Collection<ControlTableDetails>());
                }

                var requiresrepo = this.GetReoisitory<RequiredDetails>().All();
                var repomaster = this.GetReoisitory<ControlTables>();
                var repo = this.GetReoisitory();
                var repomg = this.GetReoisitory<MaterialCategories>();

                //先確認是否有管控表
                var isexistsct = (from q in repomaster.All()
                                  where q.ProjectId == ProjectId
                                  select q).SingleOrDefault();

                ControlTables master = isexistsct;

                if (master == null)
                {
                    //如果管控表示空的
                    //新增管控表(主表)
                    master = new ControlTables();

                    master.Id = Guid.NewGuid();
                    master.ProjectId = ProjectId;

                    master.CreateTime = DateTime.Now;
                    master.CreateUserId = GetCurrentLoginUser().Result.UserId;

                    var mgset = from q in repomg.All()
                                where q.Name == "鋁擠型"
                                select q;

                    if (mgset.Any())
                    {
                        var mgentry = mgset.FirstOrDefault();
                        master.MaterialCategories = mgentry;
                        master.MaterialCategoriesId = mgentry.Id;
                    }

                    repomaster.Add(master);
                    repomaster.UnitOfWork.Commit();
                    master = repomaster.Reload(master);
                }

                var orderrepo = this.GetReoisitory<Orders>();



                var result = (from q in requiresrepo
                              where q.Required.ProjectId == ProjectId
                              group q by q.MaterialsId into x
                              select x);



                //如果需求管控表細項為空
                if (master.ControlTableDetails?.Count == 0)
                {
                    //有需求表
                    if (result.Count() > 0)
                    {
                        foreach (var group in result)
                        {
                            ControlTableDetails detailitem = new ControlTableDetails();

                            detailitem.Id = Guid.NewGuid();
                            detailitem.ControlTableId = master.Id;
                            detailitem.ControlTables = master;

                            foreach (var subgroup in group)
                            {
                                detailitem.RequiredDetails.Add(subgroup);
                            }

                            detailitem.QuantityofOrderSummary = group.Sum(s => s.ControlTableDetails.Sum(l => l.OrderDetails.Sum(m => m.OrderQuantity)));
                            detailitem.TotalWeightofOrder = detailitem.QuantityofOrderSummary * detailitem.RequiredQuantityWeightSummary;
                            detailitem.RequiredQuantitySubtotal = detailitem.QuantityofOrderSummary - group.Sum(s => s.RequiredQuantity);
                            detailitem.RequiredQuantityWeightSummary = group.Sum(s => s.UnitWeight * s.RequiredQuantity);
                            detailitem.NumberofOrdersNotPlaced = group.Sum(s => s.RequiredQuantity);

                            master.ControlTableDetails.Add(detailitem);

                        }

                        repomaster.UnitOfWork.Commit();
                        master = repomaster.Reload(master);
                    }

                }

                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateResultEntity(
                    new Collection<ControlTableDetails>(master.ControlTableDetails.ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ControlTableDetails>>.CreateErrorResultEntity(ex);
            }
        }

    }
}
