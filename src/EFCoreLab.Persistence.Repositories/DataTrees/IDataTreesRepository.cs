using EFCoreLab.Persistence.Metadata.SampleDb.Entities;

namespace EFCoreLab.Persistence.Repositories.DataTrees;

public interface IDataTreesRepository
{
    Task<List<DataTreeRoot>> GetList(int id);
    Task<DataTreeRoot> Create();
}