using EFCoreLab.Persistence.Metadata.SampleDb.Entities;

namespace EFCoreLab.Persistence.Repositories.DataTrees;

public interface IDataTreesReadOnlyRepository
{
    Task<List<DataTreeRoot>> GetList(int id);
}