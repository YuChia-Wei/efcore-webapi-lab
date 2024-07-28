using System.Text.Json.Serialization;

namespace EFCore.Lab.Repository.Entities;

public partial class EndListTable
{
    public int EndId { get; set; }
    public string EndData { get; set; }
    public int? SubId { get; set; }

    [JsonIgnore]
    public virtual SubListTable Sub { get; set; }
}