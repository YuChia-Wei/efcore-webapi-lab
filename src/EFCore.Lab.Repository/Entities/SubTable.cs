using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EFCore.Lab.Repository.Entities
{
    public partial class SubTable
    {
        public SubTable()
        {
            this.DbFirstTables = new HashSet<DbFirstTable>();
        }

        public int SubId { get; set; }
        public string SubData { get; set; }
        public int? EndId { get; set; }

        public virtual EndTable End { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<DbFirstTable> DbFirstTables { get; set; }
    }
}