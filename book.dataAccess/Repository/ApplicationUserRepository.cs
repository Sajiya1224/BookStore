using book.dataAccess.data;
using book.dataAccess.Repository.IRepository;
using book.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book.dataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
      

        public void Update(ApplicationUser entity)
        {
            _db.ApplicationUsers.Update(entity);
        }

    }
}
