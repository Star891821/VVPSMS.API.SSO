using System;
using System.Collections.Generic;

namespace VVPSMSV1.API.SSO.Domain.Models
{
    public partial class MstRoleType
    {
        public MstRoleType()
        {
            MstUserRoles = new HashSet<MstUserRole>();
        }

        public int RoletypeId { get; set; }
        public string RoletypeName { get; set; } = null!;
        public int ActiveYn { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MstUserRole> MstUserRoles { get; set; }
    }
}
