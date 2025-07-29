using EFCoreLab.Persistence.Repositories.DataTrees.Dtos;

namespace EFCoreLab.Persistence.Repositories.DataTrees;

public interface IDataTreesRepository
{
    Task<DataTreeRootDto> BulkUpdate();
    Task<DataTreeRootDto> Create();
    Task<List<DataTreeRootDto>> GetList(int id);
    Task<DataTreeRootDto> Update();
}