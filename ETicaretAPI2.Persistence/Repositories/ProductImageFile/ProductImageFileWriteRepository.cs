using ETicaretAPI2.Application.Repositories.ProductImageFile;
using ETicaretAPI2.Persistence.Contexts;

namespace ETicaretAPI2.Persistence.Repositories.ProductImageFile
{
    public class ProductImageFileWriteRepository : WriteRepository<Domain.Entities.ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(ETicaretAPI2DbContext context) : base(context)
        {

        }
    }
}
