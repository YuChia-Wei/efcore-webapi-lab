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
    /// <param name="count"></param>
    /// <returns></returns>
    [HttpPost("BatchInsert")]
    public async Task<IActionResult> BatchInsertAsync([FromQuery] int count)
    {
        var insertedCount = await this._dataTreesRepository.BatchInsertAsync(count);
        return this.Ok(insertedCount);
    }

    /// <summary>
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    [HttpPatch("Bulk")]
    public async Task<IActionResult> BulkUpdateAsync([FromQuery] int skip, [FromQuery] int take)
    {
        await this._dataTreesRepository.BulkUpdateAsync(skip, take);

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

    /// <summary>
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    [HttpGet("list")]
    public async Task<IActionResult> GetListAsync([FromQuery] int skip, [FromQuery] int take)
    {
        var dbFirstTables = await this._dataTreesReadOnlyRepository.GetListAsync(skip, take);
        return this.Ok(dbFirstTables);
    }

    /// <summary>
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    [HttpPatch("PatchAndBulk")]
    public async Task<IActionResult> PatchAndBulk([FromQuery] int skip, [FromQuery] int take)
    {
        await this._dataTreesRepository.UpdateListAsync(skip, take);
        await this._dataTreesRepository.BulkUpdateAsync(skip, take);

        var dbFirstTables = await this._dataTreesReadOnlyRepository.GetListAsync(skip, take);
        return this.Ok(dbFirstTables);
    }
}