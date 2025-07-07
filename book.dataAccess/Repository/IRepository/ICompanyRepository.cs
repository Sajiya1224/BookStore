using book.Model;

namespace book.dataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company entity);

    }
}