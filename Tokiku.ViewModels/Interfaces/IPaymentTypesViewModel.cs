using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public interface IPaymentTypesViewModel : IEntityBaseViewModel<PaymentTypes>
    {
        string PaymentTypeName { get; set; }
    }
}