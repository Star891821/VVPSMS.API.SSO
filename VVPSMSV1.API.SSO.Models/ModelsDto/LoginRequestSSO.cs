﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMSV1.API.SSO.Models.ModelsDto
{
    public class LoginRequestSSO
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string UserType { get; set; }

    }
}
