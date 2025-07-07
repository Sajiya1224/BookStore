using book.dataAccess.data;
using book.dataAccess.Repository.IRepository;
using book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace book.dataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository category { get; private set; }
        public ICompanyRepository company { get; private set; }
        public IProductRepository product { get; private set; }

        

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            category = new CategoryRepository(_db);
            product = new ProductRepository(_db);
            company = new CompanyRepisitory(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
