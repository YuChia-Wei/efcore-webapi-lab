using System.Threading.Tasks;
using EFCoreLab.CrossCutting.Observability.Tracing;
using EFCoreLab.Persistence.Metadata.SampleDb.Entities;
using EFCoreLab.Persistence.Repositories.DataTrees;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreLab.WebApi.Controllers;

/// <summary>
/// </summary>
[Route("api/[controller]")]
[ApiController]
[TracingMethod]
public class DataTreeController : ControllerBase
{
    private readonly IDataTreesRepository _dataTreesRepository;

    /// <summary>
    /// </summary>
    /// <param name="dataTreesRepository"></param>
    public DataTreeController(IDataTreesRepository dataTreesRepository)
    {
        this._dataTreesRepository = dataTreesRepository;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<DataTreeRoot> GenerateAsync()
    {
        var data = await this._dataTreesRepository.Create();

        return data;
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var dbFirstTables = await this._dataTreesRepository.GetList(id);
        return this.Ok(dbFirstTables);
    }
}