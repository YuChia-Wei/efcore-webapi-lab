
using System.Collections.Generic;

namespace EFCoreLab.Persistence.Repositories.DataTrees.Dtos;

public class SubTableDto
{
    public int SubId { get; set; }
    public string SubData { get; set; }
    public int? EndId { get; set; }

    public virtual EndTableDto End { get; set; }
}
