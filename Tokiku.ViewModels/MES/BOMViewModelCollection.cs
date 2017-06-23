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
    public class BOMViewModelCollection : BaseViewModelCollection<BOMViewModel>
    {
        public BOMViewModelCollection() : base()
        {

        }
        public BOMViewModelCollection(IEnumerable<BOMViewModel> source) : base(source)
        {

        }

        public Guid ProjectId { get; set; }

        public override void Query()
        {
            try
            {

            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }

        public override void SaveModel()
        {
            try
            {
                BOMController controller = new BOMController();

                Collection<BOM> collection = new Collection<BOM>();

                if (Count > 0)
                {
                    foreach (var model in Items)
                    {
                        BOM entity = new BOM();
                        CopyToModel(entity, model);
                        entity.Id = Guid.NewGuid();
                        var executeResult = controller.GetProcessingAtlasId(model.ProcessingAtlas);

                        if (!executeResult.HasError)
                        {
                            entity.ProcessingAtlasId = executeResult.Result;
                        }
                        entity.CreateTime = DateTime.Now;
                        var createuser = controller.GetCurrentLoginUser().Result;
                        if (createuser != null)
                        {
                            entity.CreateUserId = (createuser.UserId);
                        }
                        else
                        {
                            entity.CreateUserId = Guid.Empty;
                        }

                        collection.Add(entity);
                    }

                    var executeResult2 = controller.Imports(collection);
                    if (executeResult2.HasError)
                    {
                        Errors = executeResult2.Errors;
                        HasError = executeResult2.HasError;
                    }
                }
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }
        }
    }
}
