using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Entities;

public partial class SubListTable
{
    public SubListTable()
    {
        this.EndListTables = new HashSet<EndListTable>();
    }

    public int SubId { get; set; }
    public string SubData { get; set; }
    public int? MainId { get; set; }

    [JsonIgnore]
    public virtual RootTable Main { get; set; }

    public virtual ICollection<EndListTable> EndListTables { get; set; }
}