using ETicaretAPI2.Application.Repositories;
using ETicaretAPI2.Persistence.Contexts;

namespace ETicaretAPI2.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(ETicaretAPI2DbContext context) : base(context) { }
    }

}
