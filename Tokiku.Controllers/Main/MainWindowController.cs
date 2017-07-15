using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.Controllers
{
    public class MainWindowController : BaseController<MainWindowEntity>
    {
        //ProjectsRepository ProjectRepository;
        //ManufacturersRepository ManufacturerRepository;

        public MainWindowController()
        {
            //ProjectRepository = RepositoryHelper.GetProjectsRepository(database);
            //ManufacturerRepository = RepositoryHelper.GetManufacturersRepository(database);
        }

        public ExecuteResultEntity<MainWindowEntity> Index()
        {
            try
            {
                ExecuteResultEntity<MainWindowEntity> main_model = ExecuteResultEntity<MainWindowEntity>.CreateResultEntity(new MainWindowEntity());

                main_model.Result.LoginedUser = GetCurrentLoginUser();
                main_model.Result.Projects = ExecuteResultEntity<ICollection<Projects>>.CreateResultEntity(new Collection<Projects>(this.GetReoisitory<Projects>().Where(w => w.Void == false).ToList()));
                main_model.Result.Manufacturers = ExecuteResultEntity<ICollection<Manufacturers>>
                    .CreateResultEntity(new Collection<Manufacturers>(this.GetReoisitory<Manufacturers>().Where(w => w.Void == false && w.IsClient == false).ToList()));
                main_model.Result.Clients = ExecuteResultEntity<ICollection<Manufacturers>>
                    .CreateResultEntity(new Collection<Manufacturers>(this.GetReoisitory<Manufacturers>().Where(w => w.Void == false && w.IsClient == true).ToList()));

                return main_model;

            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<MainWindowEntity>.CreateErrorResultEntity(ex);
            }
        }

        public ExecuteResultEntity<Window> Index(Window frame)
        {
            try
            {
                ExecuteResultEntity<Window> main_model = ExecuteResultEntity<Window>.CreateResultEntity(frame);

                var result = Index();

                if (!result.HasError)
                {
                    frame.DataContext = result.Result;
                }
                else
                {
                    main_model.Errors = result.Errors;
                }

                return main_model;
            }
            catch (Exception ex)
            {
                return ExecuteResultEntity<Window>.CreateErrorResultEntity(ex);
            }

        }

      
    }
}
