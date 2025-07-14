using book.dataAccess.data;
using book.dataAccess.Repository.IRepository;
using book.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace book.dataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _db;

        public OrderDetailRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public void Update(OrderDetail entity)
        {
            _db.OrderDetails.Update(entity);
        }
    }
}
