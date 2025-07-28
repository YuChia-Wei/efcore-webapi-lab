using EFCoreLab.Persistence.Metadata.SampleDb.Entities;

namespace EFCoreLab.Persistence.Repositories.Roots;

public interface ITreeDataRepository
{
    Task<List<RootTable>> GetList(int id);
    Task<RootTable> Create();
}