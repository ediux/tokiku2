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
    public class ProjectContractController : BaseController<ProjectContract>
    {

        public ProjectContractController()
        {

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
                    data.ContractNumber = string.Format("{0}-{1}", lastdata.ContractNumber.Substring(0, 7), lastnumber);
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
            var repo = RepositoryHelper.GetProjectContractRepository();

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

                var repo = this.GetRepository();
                //database = repo.UnitOfWork;

                var original = (from q in repo.All()
                                where q.Id == fromModel.Id
                                select q).Single();

                if (original != null)
                {
                    CheckAndUpdateValue(fromModel, original);



                    var toDel2 = original.ProcessingAtlas.Select(s => s.Id).Except(fromModel.ProcessingAtlas.Select(s => s.Id)).ToList();
                    var toAdd2 = fromModel.ProcessingAtlas.Select(s => s.Id).Except(original.ProcessingAtlas.Select(s => s.Id)).ToList();
                    var samerows2 = original.ProcessingAtlas.Select(s => s.Id).Intersect(fromModel.ProcessingAtlas.Select(s => s.Id)).ToList();

                    Stack<ProcessingAtlas> RemoveStack2 = new Stack<ProcessingAtlas>();
                    Stack<ProcessingAtlas> AddStack2 = new Stack<ProcessingAtlas>();

                    foreach (var delitem in toDel2)
                    {
                        RemoveStack2.Push(original.ProcessingAtlas.Where(w => w.Id == delitem).Single());
                    }

                    foreach (var additem in toAdd2)
                    {
                        AddStack2.Push(fromModel.ProcessingAtlas.Where(w => w.Id == additem).Single());
                    }

                    while (RemoveStack2.Count > 0)
                    {
                        original.ProcessingAtlas.Remove(RemoveStack2.Pop());
                    }

                    while (AddStack2.Count > 0)
                    {
                        original.ProcessingAtlas.Add(AddStack2.Pop());
                    }

                    foreach (var sameitem in samerows2)
                    {
                        ProcessingAtlas Source = fromModel.ProcessingAtlas.Where(w => w.Id == sameitem).Single();
                        ProcessingAtlas Target = original.ProcessingAtlas.Where(w => w.Id == sameitem).Single();
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
