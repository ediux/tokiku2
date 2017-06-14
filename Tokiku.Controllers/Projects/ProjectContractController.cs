﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class ProjectContractController : BaseController<ProjectContract>
    {
        private ProjectContractRepository repo;
        public ProjectContractController()
        {
            repo = RepositoryHelper.GetProjectContractRepository(database);
        }
        public override ExecuteResultEntity<ProjectContract> CreateNew()
        {
            try
            {
                ProjectContract data = new ProjectContract();
                var repo = RepositoryHelper.GetProjectContractRepository();
                var lastdata = repo.All()
                    .Where(w => w.ContractNumber.Length > 7)
                    .OrderByDescending(s => s.ContractNumber)
                    .FirstOrDefault();

                if (lastdata != null)
                {
                    int lastnumber = 0;

                    if (!int.TryParse(lastdata.ContractNumber.Substring(8), out lastnumber))
                    {
                        data.ContractNumber = string.Empty;
                        return ExecuteResultEntity<ProjectContract>.CreateResultEntity(data);
                    }
                    lastnumber += 1;
                    data.ContractNumber = string.Format("{0}-{1}", lastdata.ContractNumber.Substring(0,7),lastnumber);
                    return ExecuteResultEntity<ProjectContract>.CreateResultEntity(data);
                }
                else
                {
                    var checkori = repo.All()
                    .Where(w => w.ContractNumber.Length == 7)
                    .OrderByDescending(s => s.ContractNumber)
                    .FirstOrDefault();

                    if (checkori != null)
                    {
                        data.ContractNumber = string.Format("{0}-1", checkori.ContractNumber);

                    }
                    else
                    {
                        data.ContractNumber = "";
                    }

                    return ExecuteResultEntity<ProjectContract>.CreateResultEntity(data);

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ProjectContract>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<ProjectContract> CreateNew(Guid ProjectId)
        {
            try
            {
                ProjectContract data = new ProjectContract();
                var repo = RepositoryHelper.GetProjectContractRepository();
                var lastdata = repo.All()
                    .Where(w => w.ContractNumber.Length > 7 && w.ProjectId == ProjectId)
                    .OrderByDescending(s => s.ContractNumber)
                    .FirstOrDefault();

                if (lastdata != null)
                {
                    int lastnumber = 0;

                    if (!int.TryParse(lastdata.ContractNumber.Substring(8), out lastnumber))
                    {
                        data.ContractNumber = string.Empty;
                        return ExecuteResultEntity<ProjectContract>.CreateResultEntity(data);
                    }
                    lastnumber += 1;
                    data.ContractNumber = string.Format("{0}-{1}", lastdata.ContractNumber.Substring(0, 7), lastnumber);
                    return ExecuteResultEntity<ProjectContract>.CreateResultEntity(data);
                }
                else
                {
                    var checkori = repo.All()
                    .Where(w => w.ContractNumber.Length == 7 && w.ProjectId == ProjectId)
                    .OrderByDescending(s => s.ContractNumber)
                    .FirstOrDefault();

                    if (checkori != null)
                    {
                        data.ContractNumber = string.Format("{0}-1", checkori.ContractNumber);

                    }
                    else
                    {
                        data.ContractNumber = "";
                    }

                    return ExecuteResultEntity<ProjectContract>.CreateResultEntity(data);

                }
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ProjectContract>.CreateErrorResultEntity(ex);
            }
        }
       

        public ExecuteResultEntity<ICollection<ProjectContract>> QueryAll(Guid ProjectId)
        {
            var result = from q in repo.All()
                         where q.ProjectId == ProjectId
                         select q;

            return ExecuteResultEntity<ICollection<ProjectContract>>.CreateResultEntity(
                new Collection<ProjectContract>(result.ToList()));
        }

        public override ExecuteResultEntity<ProjectContract> Update(ProjectContract fromModel, bool isLastRecord = true)
        {
            try
            {

                var repo = RepositoryHelper.GetProjectContractRepository();
                database = repo.UnitOfWork;

                var original = (from q in repo.All()
                                where q.Id == fromModel.Id
                                select q).Single();

                if (original != null)
                {
                    CheckAndUpdateValue(fromModel, original);

                    var toDel = original.ConstructionAtlas.Select(s => s.Id).Except(fromModel.ConstructionAtlas.Select(s => s.Id)).ToList();
                    var toAdd = fromModel.ConstructionAtlas.Select(s => s.Id).Except(original.ConstructionAtlas.Select(s => s.Id)).ToList();
                    var samerows = original.ConstructionAtlas.Select(s => s.Id).Intersect(fromModel.ConstructionAtlas.Select(s => s.Id)).ToList();

                    Stack<ConstructionAtlas> RemoveStack = new Stack<ConstructionAtlas>();
                    Stack<ConstructionAtlas> AddStack = new Stack<ConstructionAtlas>();

                    foreach (var delitem in toDel)
                    {
                        RemoveStack.Push(original.ConstructionAtlas.Where(w => w.Id == delitem).Single());
                    }

                    foreach (var additem in toAdd)
                    {
                        AddStack.Push(fromModel.ConstructionAtlas.Where(w => w.Id == additem).Single());
                    }

                    while (RemoveStack.Count > 0)
                    {
                        original.ConstructionAtlas.Remove(RemoveStack.Pop());
                    }

                    while (AddStack.Count > 0)
                    {
                        original.ConstructionAtlas.Add(AddStack.Pop());
                    }

                    foreach (var sameitem in samerows)
                    {
                        ConstructionAtlas Source = fromModel.ConstructionAtlas.Where(w => w.Id == sameitem).Single();
                        ConstructionAtlas Target = original.ConstructionAtlas.Where(w => w.Id == sameitem).Single();
                        CheckAndUpdateValue(Source, Target);
                    }

                   

                    repo.UnitOfWork.Commit();

                }

                fromModel = repo.Get(original.Id);

                return ExecuteResultEntity<ProjectContract>.CreateResultEntity(fromModel);

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<ProjectContract>.CreateErrorResultEntity(ex);
            }
        }
      
    }
}
