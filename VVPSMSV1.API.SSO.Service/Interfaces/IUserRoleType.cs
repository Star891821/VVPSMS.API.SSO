using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMSV1.API.SSO.Service.Interfaces
{
    public interface IUserRoleType<T> : IGenericService<T>
    {
        T InsertOrUpdateWithResponse(T entity);
        T? GetByName(string name);
    }
}
