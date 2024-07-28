using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Lab.Repository;
using EFCore.Lab.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Lab.WebApi.Controllers;

/// <summary>
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DbIncludeController : ControllerBase
{
    private readonly EfCoreSampleContext _context;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="context"></param>
    public DbIncludeController(EfCoreSampleContext context)
    {
        this._context = context;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<DbFirstTable> GenerateAsync()
    {
        var data = new DbFirstTable
        {
            MainData = "123",
            AmountField = 123,
            DateTimeField = DateTime.Now,
            Sub = new SubTable { SubData = "this is sub", End = new EndTable { EndData = "this is end" } },
            SubListTables = new List<SubListTable>()
            {
                new SubListTable()
                {
                    SubData = "this is sub list data 1",
                    EndListTables =
                        new List<EndListTable>()
                        {
                            new EndListTable() { EndData = "this is endList data -1 for sub 1" },
                            new EndListTable() { EndData = "this is endList data -2 for sub 1" }
                        }
                },
                new SubListTable()
                {
                    SubData = "this is sub list data 2",
                    EndListTables = new List<EndListTable>()
                    {
                        new EndListTable() { EndData = "this is endList data -1 for sub 2" },
                        new EndListTable() { EndData = "this is endList data -2 for sub 2" }
                    }
                }
            }
        };

        this._context.DbFirstTables.Add(data);

        await this._context.SaveChangesAsync();

        return data;
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var dbFirstTables = await this._context.DbFirstTables
                                      .Where(o => o.MainId == id)
                                      .Include(o => o.Sub)
                                      .ThenInclude(o => o.End)
                                      .Include(o => o.SubListTables)
                                      .ThenInclude(o => o.EndListTables)
                                      .ToListAsync();
        return this.Ok(dbFirstTables);
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("EditInfo/{id:int}")]
    public async Task<IActionResult> GetEditInfoAsync(int id)
    {
        var dbFirstTables = await this._context.EditInfos
                                      .Where(o => o.EditId == id)
                                      .Include(o => o.New)
                                      .Include(o => o.Old)
                                      .ToListAsync();
        return this.Ok(dbFirstTables);
    }
}