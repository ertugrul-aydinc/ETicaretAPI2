using ETicaretAPI2.Application.Repositories;
using ETicaretAPI2.Domain.Entities;
using ETicaretAPI2.Persistence.Contexts;

namespace ETicaretAPI2.Persistence.Repositories
{
    public class MenuWriteRepository : WriteRepository<Menu>, IMenuWriteRepository
    {
        public MenuWriteRepository(ETicaretAPI2DbContext context) : base(context)
        {
        }
    }
}
