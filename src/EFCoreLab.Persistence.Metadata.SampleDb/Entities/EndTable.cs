using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Entities;

public partial class EndTable
{
    public EndTable()
    {
        this.SubTables = new HashSet<SubTable>();
    }

    public int EndId { get; set; }
    public string EndData { get; set; }

    [JsonIgnore]
    public virtual ICollection<SubTable> SubTables { get; set; }
}