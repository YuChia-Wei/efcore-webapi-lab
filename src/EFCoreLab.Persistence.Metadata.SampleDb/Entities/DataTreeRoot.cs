using System;
using System.Collections.Generic;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Entities;

/// <summary>
/// 資料樹根
/// </summary>
/// <remarks>
/// 用於測試 EFCore 的各型別與資料庫中的型別對應
/// </remarks>
public partial class DataTreeRoot
{
    public DataTreeRoot()
    {
        this.SubListTables = new HashSet<SubListTable>();
    }

    public int MainId { get; set; }
    public string MainData { get; set; }
    public decimal? AmountField { get; set; }
    public DateTime? DateTimeField { get; set; }

    // 1:1 資料
    public int? SubId { get; set; }

    public virtual SubTable Sub { get; set; }

    // 1:n 資料
    public virtual ICollection<SubListTable> SubListTables { get; set; }
}