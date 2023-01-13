using ETicaretAPI2.Application.Repositories;
using ETicaretAPI2.Persistence.Contexts;

namespace ETicaretAPI2.Persistence.Repositories.InvoiceFile
{
    public class InvoiceFileWriteRepository : WriteRepository<Domain.Entities.InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(ETicaretAPI2DbContext context) : base(context) { }

    }
}
