using ETicaretAPI2.Application.Repositories;
using ETicaretAPI2.Domain.Entities;
using ETicaretAPI2.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI2.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(ETicaretAPI2DbContext context) : base(context)
        {
        }
    }
}
