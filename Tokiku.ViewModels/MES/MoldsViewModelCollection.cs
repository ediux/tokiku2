using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MoldsViewModelCollection : BaseViewModelCollection<MoldsViewModel>
    {
        public override void Query()
        {
            try
            {
                MoldsController controller = new MoldsController();
                var executeresult = controller.Query();
                if (!executeresult.Result.HasError)
                {
                    if (executeresult.Result.Result.Any())
                    {
                        ClearItems();
                        foreach (var entity in executeresult.Result.Result)
                        {
                            MoldsViewModel model = new MoldsViewModel();
                            model.SetModel(entity);
                            //model.Manufacturers = new ManufacturersViewModel();
                            ////model.Manufacturers.SetModel(entity.Manufacturers);
                            //model.Materials = new MaterialsViewModel();
                            ////model.Materials.SetModel(entity.Materials);
                            //model.MoldUseStatus = new MoldUseStatusViewModel();
                            //model.MoldUseStatus.SetModel(entity.MoldUseStatus);
                            Add(model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
        public async override void SaveModel()
        {
            try
            {
                MoldsController controller = new MoldsController();
                MaterialManagementController MMcontroller = new MaterialManagementController();
                Collection<Molds> dataset = new Collection<Molds>();
                var logineduser = MMcontroller.GetCurrentLoginUser().Result;
                if (Items.Any())
                {
                    foreach (var model in Items)
                    {
                        Molds data = new Molds();
                        model.DoEvents();
                        CopyToModel(data, model);
                        dataset.Add(data);
                        if (model.Materials.Status.IsNewInstance)
                        {
                            model.DoEvents();
                            MMcontroller.Add(new Materials()
                            {
                                CreateTime = DateTime.Now,
                                CreateUser = logineduser,
                                CreateUserId = logineduser.UserId,
                                Id = Guid.NewGuid(),
                                ManufacturersId = model.ManufacturersId,
                                Name = model.Materials.Name,
                                UnitPrice = 0F
                            });

                        }
                    }
                }
                await controller.CreateOrUpdateAsync(dataset);
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
