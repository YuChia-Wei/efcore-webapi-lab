using EFCoreLab.Persistence.Repositories.DataTrees.Dtos;

namespace EFCoreLab.Persistence.Repositories.DataTrees;

public interface IDataTreesRepository
{
    Task<int> BatchInsertAsync(int count);
    Task BulkUpdateAsync(int skip, int take);
    Task<DataTreeRootDto> CreateAsync();
    Task<DataTreeRootDto?> GetAsync(int id);
    Task<DataTreeRootDto> UpdateAsync();
}