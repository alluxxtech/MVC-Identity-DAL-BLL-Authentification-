using DAL.Abstract;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, 
        CustomUserLogin, CustomUserRole, CustomUserClaim>, IAppDbContext
    {
        public ApplicationDbContext() : base("myDbConnection") { }

        public ApplicationDbContext(string connString) : base(connString)
        {

        }

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Category> Categories { get; set; }


        //Возвращяет довильний Entity який е в найяности

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
