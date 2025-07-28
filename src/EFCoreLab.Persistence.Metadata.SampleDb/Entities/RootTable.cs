using System;
using System.Collections.Generic;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Entities;

public partial class RootTable
{
    public RootTable()
    {
        this.SubListTables = new HashSet<SubListTable>();
    }

    public int MainId { get; set; }
    public string MainData { get; set; }
    public decimal? AmountField { get; set; }
    public DateTime? DateTimeField { get; set; }
    public int? SubId { get; set; }

    public virtual SubTable Sub { get; set; }
    public virtual ICollection<SubListTable> SubListTables { get; set; }
}