using _02IRepository;
using _03ModelGlobal.Data;
using _03ModelGlobal.Services;
using _04ModelClient.Data;
using _04ModelClient.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04ModelClient.Services
{
    public class UserClientService : IUserRepo<UserClient>
    {
        private IUserRepo<UserGlobal> _userGlobalService;
        public UserClientService()
        {
            _userGlobalService = new UserGlobalService();
        }




        public IEnumerable<UserClient> GetAll()
        {
            return _userGlobalService.GetAll().Select(user => user.ToClient());
        }

        public UserClient GetbyId(int id)
        {
            return _userGlobalService.GetbyId(id)?.ToClient();
        }

        public int Add(UserClient user)
        {
            return _userGlobalService.Add(user.ToGlobal());
        }

        public bool Edit(int id, UserClient user)
        {
            return _userGlobalService.Edit(id, user.ToGlobal());
        }

        public bool Delete(int id)
        {
            return _userGlobalService.Delete(id);
        }

        public int? CheckPassword(string identifier, string password)
        {
            return _userGlobalService.CheckPassword(identifier, password);
        }


        public bool HaveAdminRight(int id) { return _userGlobalService.HaveAdminRight(id); }

        public bool HaveDefaultRight(int id) { return _userGlobalService.HaveDefaultRight(id); }

		public void GrantAdmin(int id) => _userGlobalService.GrantAdmin(id);

		public void GrantDefault(int id) => _userGlobalService.GrantDefault(id);

		public void DenyAdmin(int id) => _userGlobalService.DenyAdmin(id);

		public void DenyDefault(int id) => _userGlobalService.DenyDefault(id);
	}
}
