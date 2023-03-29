using OnlineTest.Models.Interfaces;
using OnlineTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Services
{
    public class UserRoleService : IUserRoleService
    {
        #region Fields
        private readonly IUserRoleRepository _userRoleRepository;
        #endregion

        #region Constructor
        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        #endregion

        #region Methods
        public List<string> GetRoles(int userId)
        {
            return _userRoleRepository.GetRoles(userId);
        }
        #endregion
    }
}
