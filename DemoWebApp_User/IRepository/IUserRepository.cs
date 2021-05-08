using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    /// <summary>
    /// Interface pour les modèles.
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    public interface IUserRepository<TUser>
    {
        IEnumerable<TUser> GetAll();
        TUser GetById(int id);

        void Add(TUser user);
        bool Edit(int id, TUser user);
        bool Delete(int id);
    }
}
