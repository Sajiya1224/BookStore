using book.dataAccess.Repository.IRepository;
using book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book.dataAccess.Repository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        void Update(Category entity);
       
    }
}
