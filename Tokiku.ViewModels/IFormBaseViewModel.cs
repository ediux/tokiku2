using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.ViewModels
{
    public interface IFormBaseViewModel<TMasterPOCO, TDetailPOCO> : IDocumentBaseViewModel<TMasterPOCO>
        where TMasterPOCO : class
        where TDetailPOCO : class
    {

    }
}