using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02IRepository
{
    public interface IUserRepo<TUser>
    {
        IEnumerable<TUser> GetAll();
        TUser GetbyId(int id);
        int Add(TUser user);
        bool Edit(int id, TUser user);
        bool Delete(int id);
        int? CheckPassword(string identifier, string password);


        bool HaveAdminRight(int id);
        bool HaveDefaultRight(int id);

        void GrantAdmin(int id);
        void GrantDefault(int id);
        void DenyAdmin(int id);
        void DenyDefault(int id);
    }
}
