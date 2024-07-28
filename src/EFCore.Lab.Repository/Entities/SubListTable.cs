using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EFCore.Lab.Repository.Entities
{
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
        public virtual DbFirstTable Main { get; set; }

        public virtual ICollection<EndListTable> EndListTables { get; set; }
    }
}