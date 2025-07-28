using System.Threading.Tasks;
using EFCoreLab.Persistence.Metadata.SampleDb.Entities;
using EFCoreLab.Persistence.Repositories.Roots;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreLab.WebApi.Controllers;

/// <summary>
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DbIncludeController : ControllerBase
{
    private readonly ITreeDataRepository _treeDataRepository;

    /// <summary>
    /// </summary>
    /// <param name="treeDataRepository"></param>
    public DbIncludeController(ITreeDataRepository treeDataRepository)
    {
        this._treeDataRepository = treeDataRepository;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<RootTable> GenerateAsync()
    {
        var data = await this._treeDataRepository.Create();

        return data;
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var dbFirstTables = await this._treeDataRepository.GetList(id);
        return this.Ok(dbFirstTables);
    }
}