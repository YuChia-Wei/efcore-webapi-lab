
using System;
using System.Collections.Generic;

namespace EFCoreLab.Persistence.Repositories.DataTrees.Dtos;

public class DataTreeRootDto
{
    public int MainId { get; set; }
    public string MainData { get; set; }
    public decimal? AmountField { get; set; }
    public DateTime? DateTimeField { get; set; }
    public int? SubId { get; set; }

    public virtual SubTableDto Sub { get; set; }
    public virtual ICollection<SubListTableDto> SubListTables { get; set; }
}
