using BLL.Abstract;
using BLL.Services.Identity;
using BLL.ViewModels;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationUserManager _userManager;

        public UserProvider(IUserRepository userRepository, ApplicationUserManager userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;          
        }
        public List<UserViewModel> GetUsers(bool isAvtiv = true)
        {
            var listUsers = _userRepository
                .GetAllUsers(isAvtiv)
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Name = u.ApplicationUser.UserName,
                    Email = u.ApplicationUser.Email,
                    Image = u.Image,
                    Phone = u.Phone
                }).ToList();

            return listUsers;
        }
        private ApplicationUserManager UserManager
        {
            get
            {
                return _userManager;
            }
        }

    }
}
