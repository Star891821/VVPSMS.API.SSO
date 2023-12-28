using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMSV1.API.SSO.Service.Interfaces
{
    public interface IApplicantService<T> : IGenericService<T>
    {
        T InsertOrUpdate(T entity);
        T? GetByName(string name);

        T? GetByEmail(string emailid);
    }
}
