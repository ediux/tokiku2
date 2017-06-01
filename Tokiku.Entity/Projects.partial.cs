using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    [MetadataType(typeof(ProjectsMetaDataInfo))]
    public partial class Projects
    {

    }

    public partial class ProjectsMetaDataInfo
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "專案全名是為必要項!")]
        public string ProjectName { get; set; }
        public string ShortName { get; set; }
        public System.DateTime ProjectSigningDate { get; set; }
        public string SiteAddress { get; set; }
        public Nullable<System.Guid> ClientId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }
        public string Comment { get; set; }
        public bool Void { get; set; }
        public byte State { get; set; }

        public virtual States States { get; set; }
       
        public virtual ICollection<Manufacturers> Clients { get; set; }
        
        public virtual ICollection<ProjectContract> ProjectContract { get; set; }
    }
}
