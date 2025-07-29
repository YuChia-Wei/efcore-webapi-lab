using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Entities;

public partial class SubTable
{
    public SubTable()
    {
        this.DataTreeRoots = new HashSet<DataTreeRoot>();
    }

    public int SubId { get; set; }
    public string SubData { get; set; }
    public int? EndId { get; set; }

    public virtual EndTable End { get; set; }

    [JsonIgnore]
    public virtual ICollection<DataTreeRoot> DataTreeRoots { get; set; }
}