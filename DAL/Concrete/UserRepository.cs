using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly IAppDbContext _context;
        public UserRepository(IAppDbContext context)
        {
            _context = context;
        }
        public UserProfile AddUserProfile(UserProfile userProfile)
        {
            _context.Set<UserProfile>().Add(userProfile);
            _context.SaveChanges();
            return userProfile;
        }

        public IQueryable<UserProfile> GetAllUsers(bool isActiv = true)
        {
            var list = _context.Set<UserProfile>()
                .Where(up=>up.IsActiv || up.IsActiv == isActiv)
                .AsQueryable();
            return list;
        }
    }
}
