using System;

namespace Tokiku.Entity
{
    public interface IProfile
    {
        DateTime LastUpdatedDate { get; set; }
        string PropertyNames { get; set; }
        byte[] PropertyValuesBinary { get; set; }
        string PropertyValuesString { get; set; }
        Guid UserId { get; set; }
    }
}