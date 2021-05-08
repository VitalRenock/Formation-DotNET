using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelClient.Data;
using ModelClient.Mapper;
using ModelGlobal.Data;
using ModelGlobal.Servives;
using VitalTools.Pattern;

namespace ModelClient.Services
{
	public class UserClientService : IRepository<UserClient>
	{
		#region Properties
		
		private IRepository<UserGlobal> userRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Constructeur qui définit avec quel 'Service Global'
		/// va communiquer la classe. Le 'Service Global' doit
		/// implémenter l'interface 'IRepository'.
		/// </summary>
		public UserClientService()
		{
			userRepository = new UserGlobalService();
		}

		#endregion

		#region Public Methods

		public IEnumerable<UserClient> GetAll()
		{
			return userRepository.GetAll().Select(u => u.ToClient());
		}

		public UserClient GetById(int id)
		{
			return userRepository.GetById(id)?.ToClient();
		}

		public void Add(UserClient user)
		{
			userRepository.Add(user.ToGlobal());
		}

		public bool Edit(int id, UserClient user)
		{
			return userRepository.Edit(id, user.ToGlobal());
		}

		public bool Delete(int id)
		{
			return userRepository.Delete(id);
		}

		#endregion
	}
}
