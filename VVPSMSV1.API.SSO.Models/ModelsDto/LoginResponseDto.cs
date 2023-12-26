using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMSV1.API.SSO.Models.ModelsDto
{
    public class LoginResponseDto
    {
        public string UserName { get; set; }

        public string Role { get; set; }

        public bool Status { get; set; }

        public int Id { get; set; }

        public string email { get;set; }
    }
}
