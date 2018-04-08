using BLL.Abstract;
using BLL.Services.Identity;
using BLL.ViewModels.Identity;
using DAL.Abstract;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Providers
{
    public class AccountProvider : IAccountProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationUserManager _userManager;
        private readonly IAuthenticationManager _authManager;
        private readonly ApplicationSignInManager _singInManager;
        public AccountProvider(IUserRepository userRepository, ApplicationUserManager userManager,
            IAuthenticationManager authManager, ApplicationSignInManager signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _authManager = authManager;
            _singInManager = signInManager;

        }

        private ApplicationSignInManager SignInManager
        {
            get
            {
                return _singInManager;
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return _authManager;
            }
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return _userManager;
            }
        }

        public UserStatus Login(LoginViewModel model)
        {
            var result = SignInManager.PasswordSignIn(model.Email,model.Passport, model.RememberMe, shouldLockout: false);
            if (result == SignInStatus.Success)
                return UserStatus.Success;
            return UserStatus.Error;
        }

        public void LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        public UserStatus Register(RegisterViewModel model)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    UserProfile userProfile = new UserProfile
                    {
                        Id = user.Id,
                        IsActiv = true,
                        Phone = model.Phone
                    };
                    _userRepository.AddUserProfile(userProfile);
                    return UserStatus.Success;
                }

            }
            catch
            {

            }
            throw new Exception("bay");
            //ApplicationDbContext context = new ApplicationDbContext();
            //return UserStatus.Success;
        }
    }
}
