using EFCoreLab.Persistence.Repositories.DataTrees.Dtos;

namespace EFCoreLab.Persistence.Repositories.DataTrees;

public interface IDataTreesReadOnlyRepository
{
    Task<List<DataTreeRootDto>> GetListAsync(int skip, int take);
}