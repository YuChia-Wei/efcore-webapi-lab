using System.Threading.Tasks;
using EFCoreLab.CrossCutting.Observability.Tracing;
using EFCoreLab.Persistence.Repositories.DataTrees;
using EFCoreLab.Persistence.Repositories.DataTrees.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreLab.WebApi.Controllers;

/// <summary>
/// </summary>
[Route("api/[controller]")]
[ApiController]
[TracingMethod]
public class DataTreeController : ControllerBase
{
    private readonly IDataTreesReadOnlyRepository _dataTreesReadOnlyRepository;
    private readonly IDataTreesRepository _dataTreesRepository;

    /// <summary>
    /// </summary>
    /// <param name="dataTreesRepository"></param>
    /// <param name="dataTreesReadOnlyRepository"></param>
    public DataTreeController(IDataTreesRepository dataTreesRepository, IDataTreesReadOnlyRepository dataTreesReadOnlyRepository)
    {
        this._dataTreesRepository = dataTreesRepository;
        this._dataTreesReadOnlyRepository = dataTreesReadOnlyRepository;
    }

    /// <summary>
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    [HttpPatch("Bulk")]
    public async Task<IActionResult> BulkUpdateAsync([FromQuery] int skip, [FromQuery] int take)
    {
        await this._dataTreesRepository.BulkUpdateAsync(1, 10);

        var dbFirstTables = await this._dataTreesReadOnlyRepository.GetListAsync(skip, take);
        return this.Ok(dbFirstTables);
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<DataTreeRootDto> GenerateAsync()
    {
        var data = await this._dataTreesRepository.CreateAsync();

        return data;
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var dbFirstTables = await this._dataTreesRepository.GetAsync(id);
        return this.Ok(dbFirstTables);
    }
}