using EFCoreLab.CrossCutting.Observability.Tracing;
using EFCoreLab.Persistence.Metadata.SampleDb;
using EFCoreLab.Persistence.Metadata.SampleDb.Entities;
using EFCoreLab.Persistence.Repositories.DataTrees.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLab.Persistence.Repositories.DataTrees;

[TracingMethod]
public class DataTreesInSampleDbRepository : IDataTreesRepository
{
    private readonly SampleDbContext _context;

    public DataTreesInSampleDbRepository(SampleDbContext context)
    {
        this._context = context;
    }

    public async Task<DataTreeRootDto?> GetAsync(int id)
    {
        var dbFirstTables = await this._context.RootTables
                                      .Where(o => o.MainId == id)
                                      .Include(o => o.Sub)
                                      .ThenInclude(o => o.End)
                                      .Include(o => o.SubListTables)
                                      .ThenInclude(o => o.EndListTables)
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

        return result.FirstOrDefault();
    }

    public async Task<DataTreeRootDto> CreateAsync()
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

        // Manual mapping
        var result = new DataTreeRootDto
        {
            MainId = data.MainId,
            MainData = data.MainData,
            AmountField = data.AmountField,
            DateTimeField = data.DateTimeField,
            SubId = data.SubId,
            Sub = data.Sub == null
                      ? null
                      : new SubTableDto
                      {
                          SubId = data.Sub.SubId,
                          SubData = data.Sub.SubData,
                          EndId = data.Sub.EndId,
                          End = data.Sub.End == null
                                    ? null
                                    : new EndTableDto
                                    {
                                        EndId = data.Sub.End.EndId,
                                        EndData = data.Sub.End.EndData
                                    }
                      },
            SubListTables = data.SubListTables.Select(s => new SubListTableDto
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
        };

        return result;
    }

    public async Task<DataTreeRootDto> UpdateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task BulkUpdateAsync(int skip, int take)
    {
        await this._context.RootTables
                  .Skip(skip)
                  .Take(take)
                  .ExecuteUpdateAsync(o => o.SetProperty(p => p.DateTimeField, DateTime.Now));
    }

    public async Task<int> BatchInsertAsync(int count)
    {
        var random = new Random();
        for (var i = 0; i < count; i++)
        {
            var data = new DataTreeRoot
            {
                MainData = Guid.NewGuid().ToString(),
                AmountField = random.Next(1, 1000),
                DateTimeField = DateTime.UtcNow,
                Sub = new SubTable
                {
                    SubData = Guid.NewGuid().ToString(),
                    End = new EndTable
                    {
                        EndData = Guid.NewGuid().ToString()
                    }
                },
                SubListTables = new List<SubListTable>
                {
                    new SubListTable
                    {
                        SubData = Guid.NewGuid().ToString(),
                        EndListTables = new List<EndListTable>
                        {
                            new EndListTable
                            {
                                EndData = Guid.NewGuid().ToString()
                            },
                            new EndListTable
                            {
                                EndData = Guid.NewGuid().ToString()
                            }
                        }
                    },
                    new SubListTable
                    {
                        SubData = Guid.NewGuid().ToString(),
                        EndListTables = new List<EndListTable>
                        {
                            new EndListTable
                            {
                                EndData = Guid.NewGuid().ToString()
                            },
                            new EndListTable
                            {
                                EndData = Guid.NewGuid().ToString()
                            }
                        }
                    }
                }
            };
            this._context.RootTables.Add(data);
        }

        await this._context.SaveChangesAsync();
        return count;
    }
}