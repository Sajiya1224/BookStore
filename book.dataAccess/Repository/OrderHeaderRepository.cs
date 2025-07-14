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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

     
        public void Update(OrderHeader entity)
        {
            _db.OrderHeaders.Update(entity);
        }
    }
}
