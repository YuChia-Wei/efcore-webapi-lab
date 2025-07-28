using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Entities;

public partial class SubTable
{
    public SubTable()
    {
        this.DbFirstTables = new HashSet<RootTable>();
    }

    public int SubId { get; set; }
    public string SubData { get; set; }
    public int? EndId { get; set; }

    public virtual EndTable End { get; set; }

    [JsonIgnore]
    public virtual ICollection<RootTable> DbFirstTables { get; set; }
}