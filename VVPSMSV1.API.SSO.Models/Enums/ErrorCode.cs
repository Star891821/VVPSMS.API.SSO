using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMSV1.API.SSO.Models.Enums
{
    public enum ErrorCode
    {
        None = 0,
        Duplicate = 1,
        MissingData = 2,
        MissingFocus = 3,
        NoSampleCode = 4,
        AlreadyExist = 5,
        NotFound = 6
    }
}
