using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMSV1.API.SSO.Models.ModelsDto
{
    public class LoginResponseSSO
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string LoginStatus { get; set; }

        public string? Email { get; set; }
    }
}
