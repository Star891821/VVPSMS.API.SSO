using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMSV1.API.SSO.Models.Enums
{
    public class Enum<T> where T : Enum
    {
        public static IEnumerable<T> GetAllValuesAsIEnumerable()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
