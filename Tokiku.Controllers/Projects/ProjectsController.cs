using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ProjectsController : BaseController<Projects>
    {
        IUsersRepository UserRepo;
        IManufacturersRepository manufacturerepo;
        IProjectsRepository projectsrepo;
        IStatesRepository staterepo;

        public ProjectsController()
        {
            UserRepo = this.GetReoisitory<Users>() as IUsersRepository;
            manufacturerepo = this.GetReoisitory<Manufacturers>() as IManufacturersRepository;
            projectsrepo = this.GetReoisitory() as IProjectsRepository;
            staterepo = this.GetReoisitory<States>() as IStatesRepository;
        }


        ///// <summary>
        ///// 儲存變更
        ///// </summary>
        //public override void SaveModel(ProjectsViewModel model)
        //{
        //    try
        //    {
        //        if (IsExists(model.Id))
        //        {
        //            Update(model);
        //        }
        //        else
        //        {
        //            Add(model);

        //        }

        //        model.Status.IsSaved = true;
        //        model.Status.IsModify = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (model == null)
        //        {
        //            model = CreateNew();
        //        }
        //        setErrortoModel(model, ex);
        //    }

        //}

        public override ExecuteResultEntity<Projects> CreateNew()
        {
            try
            {
                var newmodel = new Projects()
                {
                    Id = Guid.NewGuid(),
                    Code = string.Format("{0:000}-{1}", DateTime.Today.Year - 1911, GetNextProjectSerialNumber((DateTime.Now.Year - 1911).ToString()).Result),
                    ProjectSigningDate = DateTime.Today,
                    StartDate = DateTime.Today,
                    CreateTime = DateTime.Now,


                };

                return ExecuteResultEntity<Projects>.CreateResultEntity(newmodel);
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Projects>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<string> GetNextProjectSerialNumber(string year)
        {
            var result = (from q in projectsrepo.All()
                          where q.Code.StartsWith(year.Trim()) && q.Void == false
                          orderby q.Code descending
                          select q.Code).FirstOrDefault();

            if (!string.IsNullOrEmpty(result))
            {
                string[] parts = result.Split('-');

                if (parts.Any() && parts.Length >= 1)
                {
                    int currentNumber = 0;

                    if (int.TryParse(parts[1], out currentNumber))
                    {
                        currentNumber += 1;
                        return ExecuteResultEntity<string>.CreateResultEntity(string.Format("{0:000}", currentNumber));
                    }
                }

            }

            return ExecuteResultEntity<string>.CreateResultEntity("001");
        }

        //public override ExecuteResultEntity Add(Projects entity)     
        //{
        //    try
        //    {
        //        using (database)
        //        {
        //            var LoginedUser = usercontroller.GetCurrentLoginUser();
        //            Projects newProject = new Projects();
        //            //newProject.ProjectName = "";
        //            //newProject.Id = model.Id;
        //            model.CreateTime = DateTime.Now;
        //            model.CreateUserId = LoginedUser.UserId;
        //            CopyToModel(newProject, model);

        //            if (model.ClientId.HasValue)
        //            {
        //                var custommodel = (from q in database.Manufacturers
        //                                   where q.Id == model.ClientId.Value
        //                                   select q).SingleOrDefault();

        //                if (custommodel != null)
        //                {
        //                    newProject.Clients.Add(custommodel);
        //                }

        //            }

        //            if (model.ProjectContract.Any())
        //            {
        //                foreach (var row in model.ProjectContract)
        //                {
        //                    ProjectContract newdata = new ProjectContract();

        //                    newdata.AmountDue = 0F;
        //                    newdata.Area = 0F;
        //                    CopyToModel(newdata, row);
        //                    newdata.ProjectId = newProject.Id;
        //                    newdata.SigningDate = model.ProjectSigningDate;

        //                    newProject.ProjectContract.Add(newdata);
        //                }
        //            }

        //            database.Projects.Add(newProject);
        //            database.SaveChanges();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        setErrortoModel(model, ex);
        //    }
        //    finally
        //    {

        //        database = new TokikuEntities();
        //    }
        //}

        public ExecuteResultEntity<Projects> QuerySingle(Guid ProjectId)
        {
            try
            {
                var result = from p in projectsrepo.All()
                             where p.Id == ProjectId && p.Void == false
                             orderby p.State ascending, p.Code ascending
                             select p;

                if (result.Any())
                {
                    var model = result.Single();


                    return ExecuteResultEntity<Projects>.CreateResultEntity(model);
                }

                return ExecuteResultEntity<Projects>.CreateResultEntity(default(Projects));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Projects>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ICollection<ProjectListEntity>> QueryAll()
        {
            try
            {

                var result = from p in projectsrepo.All()
                             where p.Void == false
                             orderby p.State ascending, p.Code descending
                             select new ProjectListEntity
                             {
                                 Id = p.Id,
                                 Code = p.Code,
                                 Name = p.Name,
                                 ShortName = p.ShortName,
                                 State = p.State,
                                 StateText = p.States.StateName,
                                 StartDate = p.StartDate,
                                 CompletionDate = p.PromissoryNoteManagement.Any(s => s.TicketTypeId == 3 || s.TicketTypeId == 4) ? p.PromissoryNoteManagement.Where(s => s.TicketTypeId == 3 || s.TicketTypeId == 4).OrderByDescending(o => o.CreateTime).FirstOrDefault().CreateTime : default(DateTime?),
                                 WarrantyDate = p.PromissoryNoteManagement.Any(k => k.TicketTypeId == 3 || k.TicketTypeId == 4) ? p.PromissoryNoteManagement.Where(k => k.TicketTypeId == 3 || k.TicketTypeId == 4).OrderByDescending(w => w.RecoveryDate).FirstOrDefault().RecoveryDate : default(DateTime?)
                             };

                return ExecuteResultEntity<ICollection<ProjectListEntity>>.CreateResultEntity(
                    new Collection<ProjectListEntity>(result.ToList()));


            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ProjectListEntity>>.CreateErrorResultEntity(ex);
            }

        }

        public bool IsExists(Guid ProjectId)
        {
            try
            {
                var result = from p in projectsrepo.All()
                             where p.Id == ProjectId && p.Void == false
                             orderby p.Code descending, p.State ascending
                             select p;

                return result.Any();
            }
            catch
            {

                return false;
            }
        }

        public ExecuteResultEntity<ICollection<States>> GetStates()
        {
            try
            {
                return ExecuteResultEntity<ICollection<States>>.CreateResultEntity(
                    new Collection<States>(staterepo.All().ToList()));
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<States>>.CreateErrorResultEntity(ex);
            }
        }
        public override ExecuteResultEntity<Projects> Update(Projects fromModel, bool isLastRecord = true)
        {
            try
            {

                var original = (from q in projectsrepo.All()
                                where q.Id == fromModel.Id
                                select q).Single();

                if (original != null)
                {
                    CheckAndUpdateValue(fromModel, original);

                    var toDel = original.ProjectContract.Select(s => s.Id).Except(fromModel.ProjectContract.Select(s => s.Id)).ToList();
                    var toAdd = fromModel.ProjectContract.Select(s => s.Id).Except(original.ProjectContract.Select(s => s.Id)).ToList();
                    var samerows = original.ProjectContract.Select(s => s.Id).Intersect(fromModel.ProjectContract.Select(s => s.Id)).ToList();

                    Stack<ProjectContract> RemoveStack = new Stack<ProjectContract>();
                    Stack<ProjectContract> AddStack = new Stack<ProjectContract>();

                    foreach (var delitem in toDel)
                    {
                        RemoveStack.Push(original.ProjectContract.Where(w => w.Id == delitem).Single());
                    }

                    foreach (var additem in toAdd)
                    {
                        AddStack.Push(fromModel.ProjectContract.Where(w => w.Id == additem).Single());
                    }

                    while (RemoveStack.Count > 0)
                    {
                        original.ProjectContract.Remove(RemoveStack.Pop());
                    }

                    while (AddStack.Count > 0)
                    {
                        original.ProjectContract.Add(AddStack.Pop());
                    }

                    foreach (var sameitem in samerows)
                    {
                        ProjectContract Source = fromModel.ProjectContract.Where(w => w.Id == sameitem).Single();
                        ProjectContract Target = original.ProjectContract.Where(w => w.Id == sameitem).Single();
                        CheckAndUpdateValue(Source, Target);
                    }

                    var toDelBI = original.SupplierTranscationItem.Select(s => new { s.ProjectId, s.ManufacturersBussinessItemsId })
                        .Except(fromModel.SupplierTranscationItem.Select(s => new { s.ProjectId, s.ManufacturersBussinessItemsId })).ToList();
                    var toAddBI = fromModel.SupplierTranscationItem.Select(s => new { s.ProjectId, s.ManufacturersBussinessItemsId }).Except(original.SupplierTranscationItem.Select(s => new { s.ProjectId, s.ManufacturersBussinessItemsId })).ToList();
                    var samerowsBI = original.SupplierTranscationItem.Select(s => new { s.ProjectId, s.ManufacturersBussinessItemsId }).Intersect(fromModel.SupplierTranscationItem.Select(s => new { s.ProjectId, s.ManufacturersBussinessItemsId })).ToList();

                    Stack<SupplierTranscationItem> RemoveStackBI = new Stack<SupplierTranscationItem>();
                    Stack<SupplierTranscationItem> AddStackBI = new Stack<SupplierTranscationItem>();

                    foreach (var delitem in toDelBI)
                    {
                        RemoveStackBI.Push(original.SupplierTranscationItem.Where(w => w.ProjectId == delitem.ProjectId && w.ManufacturersBussinessItemsId == delitem.ManufacturersBussinessItemsId).Single());
                    }

                    foreach (var additem in toAddBI)
                    {
                        AddStackBI.Push(fromModel.SupplierTranscationItem.Where(w => w.ProjectId == additem.ProjectId && w.ManufacturersBussinessItemsId == additem.ManufacturersBussinessItemsId).Single());
                    }

                    while (RemoveStackBI.Count > 0)
                    {
                        original.SupplierTranscationItem.Remove(RemoveStackBI.Pop());
                    }

                    while (AddStackBI.Count > 0)
                    {
                        original.SupplierTranscationItem.Add(AddStackBI.Pop());
                    }

                    foreach (var sameitem in samerowsBI)
                    {
                        SupplierTranscationItem Source = fromModel.SupplierTranscationItem.Where(w => w.ProjectId == sameitem.ProjectId && w.ManufacturersBussinessItemsId == sameitem.ManufacturersBussinessItemsId).Single();
                        SupplierTranscationItem Target = original.SupplierTranscationItem.Where(w => w.ProjectId == sameitem.ProjectId && w.ManufacturersBussinessItemsId == sameitem.ManufacturersBussinessItemsId).Single();
                        CheckAndUpdateValue(Source, Target);
                    }

                    #region 施工圖集
                    var toDel3 = original.ConstructionAtlas.Select(s => s.Id).Except(fromModel.ConstructionAtlas.Select(s => s.Id)).ToList();
                    var toAdd3 = fromModel.ConstructionAtlas.Select(s => s.Id).Except(original.ConstructionAtlas.Select(s => s.Id)).ToList();
                    var samerows3 = original.ConstructionAtlas.Select(s => s.Id).Intersect(fromModel.ConstructionAtlas.Select(s => s.Id)).ToList();

                    Stack<ConstructionAtlas> RemoveStack3 = new Stack<ConstructionAtlas>();
                    Stack<ConstructionAtlas> AddStack3 = new Stack<ConstructionAtlas>();

                    foreach (var delitem in toDel3)
                    {
                        RemoveStack3.Push(original.ConstructionAtlas.Where(w => w.Id == delitem).Single());
                    }

                    foreach (var additem in toAdd3)
                    {
                        AddStack3.Push(fromModel.ConstructionAtlas.Where(w => w.Id == additem).Single());
                    }

                    while (RemoveStack3.Count > 0)
                    {
                        original.ConstructionAtlas.Remove(RemoveStack3.Pop());
                    }

                    while (AddStack3.Count > 0)
                    {
                        original.ConstructionAtlas.Add(AddStack3.Pop());
                    }

                    foreach (var sameitem in samerows)
                    {
                        try
                        {
                            ConstructionAtlas Source = fromModel.ConstructionAtlas.Where(w => w.Id == sameitem).Single();
                            ConstructionAtlas Target = original.ConstructionAtlas.Where(w => w.Id == sameitem).Single();
                            CheckAndUpdateValue(Source, Target);

                        }
                        catch
                        {
                            continue;
                        }

                    }
                    #endregion

                    projectsrepo.UnitOfWork.Commit();

                }

                fromModel = projectsrepo.Get(original.Id);

                return ExecuteResultEntity<Projects>.CreateResultEntity(fromModel);

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Projects>.CreateErrorResultEntity(ex);
            }

        }


        public void Delete(Guid ProjectId, Guid UserId)
        {
            try
            {

                var result = from p in projectsrepo.All()
                             where p.Id == ProjectId && p.Void == false
                             orderby p.State ascending, p.Code ascending
                             select p;

                if (result.Any())
                {
                    var data = result.Single();
                    data.Void = true;
                    Update(data);
                }

            }
            catch (Exception)
            {

            }
        }

        public ExecuteResultEntity<ICollection<ProjectListEntity>> SearchByText(string text)
        {

            try
            {
                if (text != null && text.Length > 0)
                {
                    var result = projectsrepo.Where(s => s.Code.Contains(text)
                     || s.Name.Contains(text)
                    || (s.ShortName != null && s.ShortName.Contains(text)))
                    .OrderByDescending(s => s.Code)
                    .OrderBy(s => s.State)
                    .Select(s => new ProjectListEntity()
                    {
                        Id = s.Id,
                        Code = s.Code,
                        Name = s.Name,
                        ShortName = s.ShortName,
                        State = s.State,
                        StateText = s.States.StateName,
                        StartDate = s.StartDate,
                        CompletionDate = s.PromissoryNoteManagement.Any(k => k.TicketTypeId == 3 || k.TicketTypeId == 4) ? s.PromissoryNoteManagement.Where(k => k.TicketTypeId == 3 || k.TicketTypeId == 4).OrderByDescending(o => o.CreateTime).FirstOrDefault().CreateTime : default(DateTime?),
                        WarrantyDate = s.PromissoryNoteManagement.Any(k => k.TicketTypeId == 3 || k.TicketTypeId == 4) ? s.PromissoryNoteManagement.Where(k => k.TicketTypeId == 3 || k.TicketTypeId == 4).OrderByDescending(w => w.RecoveryDate).FirstOrDefault().RecoveryDate : default(DateTime?)
                    })
                    .ToList();

                    ExecuteResultEntity<ICollection<ProjectListEntity>> model = ExecuteResultEntity<ICollection<ProjectListEntity>>
                         .CreateResultEntity(new Collection<ProjectListEntity>(result));

                    return model;
                }
                else
                {
                    var result = QueryAll();
                    return result;

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ICollection<ProjectListEntity>>.CreateErrorResultEntity(ex);
            }

        }
    }
}
