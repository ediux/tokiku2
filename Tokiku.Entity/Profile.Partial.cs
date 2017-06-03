namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProfileMetaData))]
    public partial class Profile
    {
    }
    
    public partial class ProfileMetaData
    {
        [Required]
        public System.Guid UserId { get; set; }
        [Required]
        public string PropertyNames { get; set; }
        [Required]
        public string PropertyValuesString { get; set; }
        [Required]
        public byte[] PropertyValuesBinary { get; set; }
        [Required]
        public System.DateTime LastUpdatedDate { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
