using EFCoreLab.CrossCutting.Observability.Tracing;
using EFCoreLab.Persistence.Metadata.SampleDb;
using EFCoreLab.Persistence.Metadata.SampleDb.Entities;

namespace EFCoreLab.Persistence.Repositories.DataTrees;

[TracingMethod]
internal class DataTreesInSampleDbReadOnlyRepository : IDataTreesReadOnlyRepository
{
    private readonly ReadOnlySampleDbContext _context;

    public DataTreesInSampleDbReadOnlyRepository(ReadOnlySampleDbContext context)
    {
        this._context = context;
    }

    public Task<List<DataTreeRoot>> GetList(int id)
    {
        throw new NotImplementedException();
    }
}