using ETicaretAPI2.Application.Repositories;
using ETicaretAPI2.Domain.Entities;
using ETicaretAPI2.Persistence.Contexts;

namespace ETicaretAPI2.Persistence.Repositories
{
    public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(ETicaretAPI2DbContext context) : base(context)
        {
        }
    }
}
