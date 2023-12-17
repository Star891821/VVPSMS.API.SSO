using System;
using System.Collections.Generic;

namespace VVPSMSV1.API.SSO.Domain.Models
{
    public partial class MstUserRole
    {
        public MstUserRole()
        {
            MstUsers = new HashSet<MstUser>();
            RolePermissionsMappings = new HashSet<RolePermissionsMapping>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public int ActiveYn { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public int? RoletypeId { get; set; }

        public virtual MstRoleType? Roletype { get; set; }
        public virtual ICollection<MstUser> MstUsers { get; set; }
        public virtual ICollection<RolePermissionsMapping> RolePermissionsMappings { get; set; }
    }
}
