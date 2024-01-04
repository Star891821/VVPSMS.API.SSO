using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMSV1.API.SSO.Models.ModelsDto
{
    public class CommonResponse
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }
    }
    public class NewLoginResponseDto : CommonResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string GivenName { get; set; }

        public string SurName { get; set; }

        public string Phone { get; set; }

        public string Role { get; set; }
    }
}
