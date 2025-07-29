using EFCoreLab.CrossCutting.Observability.Tracing;
using EFCoreLab.Persistence.Metadata.SampleDb;
using EFCoreLab.Persistence.Metadata.SampleDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLab.Persistence.Repositories.DataTrees;

[TracingMethod]
public class DataTreesInSampleDbRepository : IDataTreesRepository
{
    private readonly SampleDbContext _context;

    /// <summary>
    /// Provides data access operations for orders and related entities in the database.
    /// This repository interacts with the `SampleDbContext` to perform CRUD operations.
    /// Implements the `IOrderRepository` interface.
    /// </summary>
    public DataTreesInSampleDbRepository(SampleDbContext context)
    {
        this._context = context;
    }

    public async Task<List<DataTreeRoot>> GetList(int id)
    {
        var dbFirstTables = await this._context.RootTables
                                      .Where(o => o.MainId == id)
                                      .Include(o => o.Sub)
                                      .ThenInclude(o => o.End)
                                      .Include(o => o.SubListTables)
                                      .ThenInclude(o => o.EndListTables)
                                      .ToListAsync();
        return dbFirstTables;
    }

    public async Task<DataTreeRoot> Create()
    {
        var data = new DataTreeRoot
        {
            MainData = "123",
            AmountField = 123,
            DateTimeField = DateTime.Now,
            Sub = new SubTable
            {
                SubData = "this is sub",
                End = new EndTable
                {
                    EndData = "this is end"
                }
            },
            SubListTables = new List<SubListTable>
            {
                new SubListTable
                {
                    SubData = "this is sub list data 1",
                    EndListTables =
                        new List<EndListTable>
                        {
                            new EndListTable
                            {
                                EndData = "this is endList data -1 for sub 1"
                            },
                            new EndListTable
                            {
                                EndData = "this is endList data -2 for sub 1"
                            }
                        }
                },
                new SubListTable
                {
                    SubData = "this is sub list data 2",
                    EndListTables = new List<EndListTable>
                    {
                        new EndListTable
                        {
                            EndData = "this is endList data -1 for sub 2"
                        },
                        new EndListTable
                        {
                            EndData = "this is endList data -2 for sub 2"
                        }
                    }
                }
            }
        };

        this._context.RootTables.Add(data);

        await this._context.SaveChangesAsync();
        return data;
    }

    public Task<DataTreeRoot> Update()
    {
        throw new NotImplementedException();
    }

    public Task<DataTreeRoot> BulkUpdate()
    {
        throw new NotImplementedException();
    }
}