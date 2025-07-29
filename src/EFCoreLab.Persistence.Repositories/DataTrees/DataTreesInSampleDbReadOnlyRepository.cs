using EFCoreLab.CrossCutting.Observability.Tracing;
using EFCoreLab.Persistence.Metadata.SampleDb;
using EFCoreLab.Persistence.Repositories.DataTrees.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLab.Persistence.Repositories.DataTrees;

[TracingMethod]
internal class DataTreesInSampleDbReadOnlyRepository : IDataTreesReadOnlyRepository
{
    private readonly ReadOnlySampleDbContext _context;

    public DataTreesInSampleDbReadOnlyRepository(ReadOnlySampleDbContext context)
    {
        this._context = context;
    }

    public async Task<List<DataTreeRootDto>> GetListAsync(int skip, int take)
    {
        var dbFirstTables = await this._context.RootTables
                                      .Include(o => o.Sub)
                                      .ThenInclude(o => o.End)
                                      .Include(o => o.SubListTables)
                                      .ThenInclude(o => o.EndListTables)
                                      .Skip(skip + 1)
                                      .Take(take)
                                      .ToListAsync();

        // Manual mapping
        var result = dbFirstTables.Select(o => new DataTreeRootDto
        {
            MainId = o.MainId,
            MainData = o.MainData,
            AmountField = o.AmountField,
            DateTimeField = o.DateTimeField,
            SubId = o.SubId,
            Sub = o.Sub == null
                      ? null
                      : new SubTableDto
                      {
                          SubId = o.Sub.SubId,
                          SubData = o.Sub.SubData,
                          EndId = o.Sub.EndId,
                          End = o.Sub.End == null
                                    ? null
                                    : new EndTableDto
                                    {
                                        EndId = o.Sub.End.EndId,
                                        EndData = o.Sub.End.EndData
                                    }
                      },
            SubListTables = o.SubListTables.Select(s => new SubListTableDto
            {
                SubId = s.SubId,
                SubData = s.SubData,
                MainId = s.MainId,
                EndListTables = s.EndListTables.Select(e => new EndListTableDto
                {
                    EndId = e.EndId,
                    EndData = e.EndData,
                    SubId = e.SubId
                }).ToList()
            }).ToList()
        }).ToList();

        return result;
    }
}