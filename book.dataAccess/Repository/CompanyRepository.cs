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
    public class CompanyRepisitory : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;

        public CompanyRepisitory(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
      

        public void Update(Company entity)
        {
            _db.Companies.Update(entity);
        }
    }
}
