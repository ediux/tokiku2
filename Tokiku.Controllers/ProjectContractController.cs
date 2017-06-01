using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using Tokiku.ViewModels;

namespace Tokiku.Controllers
{
    public class ProjectContractController : BaseController<ProjectContractViewModel, ProjectContract>
    {
        public override ProjectContractViewModel CreateNew()
        {
            var rtn = new ProjectContractViewModel() { Id = Guid.NewGuid() };
            EngineeringController engcontroller = new EngineeringController();
            rtn.Engineerings = new EngineeringViewModelCollection();

            EngineeringViewModel defaultNew = engcontroller.CreateNew();
            rtn.Engineerings.Add(defaultNew);
            rtn.PromissoryNoteManagement = new PromissoryNoteManagementViewModelCollection();

            return rtn;
        }

        public override ProjectContractViewModel Query(Expression<Func<ProjectContract, bool>> filiter)
        {
            try
            {
                var result = (from q in database.ProjectContract
                              select q)
                      .Where(filiter)
                      .SingleOrDefault();

                var rtn = ResultBindToViewModel(result);

                return rtn;
            }
            catch (Exception ex)
            {
                ProjectContractViewModel model = new ProjectContractViewModel();
                setErrortoModel(model, ex);
                return model;
            }

        }

        public override void Add(ProjectContractViewModel model)
        {
            try
            {
                using (database)
                {
                    ProjectContract entity = new ProjectContract();
                    CopyToModel(entity, model);
                    if (model.Engineerings.Any())
                    {
                        foreach (var eng in model.Engineerings)
                        {
                            Engineering engmodel = new Engineering();
                            CopyToModel(engmodel, eng);
                            engmodel.ProjectContractId = model.Id;
                            entity.Engineering.Add(engmodel);
                        }
                    }

                    if (model.PromissoryNoteManagement.Any())
                    {
                        foreach (var row in model.PromissoryNoteManagement)
                        {
                            PromissoryNoteManagement PNMRow = new PromissoryNoteManagement();
                            CopyToModel(PNMRow, row);

                            entity.PromissoryNoteManagement.Add(PNMRow);
                        }
                    }
                    database.ProjectContract.Add(entity);
                    database.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                setErrortoModel(model, ex);
            }
            finally
            {
                database = new TokikuEntities();
            }
        }

        public ProjectContractViewModelCollection QueryAll(Guid ProjectId)
        {
            var result = from q in database.ProjectContract
                         where q.ProjectId == ProjectId
                         select q;

            var rtn = ResultBindToViewModelCollection(result);

            return rtn;
        }

        private ProjectContractViewModel ResultBindToViewModel(ProjectContract entity)
        {
            try
            {
                ProjectContractViewModel model = BindingFromModel(entity);

                model.Engineerings = new EngineeringViewModelCollection();

                if (entity.Engineering.Any())
                {
                    foreach (var row in entity.Engineering)
                    {
                        model.Engineerings.Add(BindingFromModel<EngineeringViewModel, Engineering>(row));
                    }
                }

                model.PromissoryNoteManagement = new PromissoryNoteManagementViewModelCollection();

                if (entity.PromissoryNoteManagement.Any())
                {
                    foreach (var row in entity.PromissoryNoteManagement)
                    {

                    }
                }

                return model;
            }
            catch (Exception ex)
            {
                ProjectContractViewModel model = new ProjectContractViewModel();
                setErrortoModel(model, ex);
                return model;
            }
        }

        private ProjectContractViewModelCollection ResultBindToViewModelCollection(IQueryable<ProjectContract> queries)
        {
            ProjectContractViewModelCollection rtn = new ProjectContractViewModelCollection();
            try
            {
                if (queries.Any())
                {
                    foreach (var row in queries)
                    {
                        rtn.Add(ResultBindToViewModel(row));
                    }
                }

                return rtn;
            }
            catch (Exception ex)
            {
                setErrortoModel(rtn, ex);
                return rtn;
            }
        }
    }
}
