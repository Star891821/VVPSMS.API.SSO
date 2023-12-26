using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMSV1.API.SSO.Models.ModelsDto
{
    public class ApplicantDto
    {
        public int ApplicantId { get; set; }

        public string Applicantname { get; set; } = null!;

        public string Applicantpassword { get; set; } = null!;

        public string ApplicantGivenName { get; set; } = null!;

        public string ApplicantSurname { get; set; } = null!;

        public string? ApplicantPhone { get; set; }

        public int RoleId { get; set; }

        public string ApplicantLoginType { get; set; } = null!;

        public int Enforce2Fa { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? LastloginAt { get; set; }

        public string? Applicantemail { get; set; }

    }
}
