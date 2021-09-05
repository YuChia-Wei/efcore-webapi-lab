using System.Collections.Generic;
using Newtonsoft.Json;

#nullable disable

namespace LabWebApi.Repository.Entities
{
    public partial class SubListTable
    {
        public SubListTable()
        {
            EndListTables = new HashSet<EndListTable>();
        }

        public int SubId { get; set; }
        public string SubData { get; set; }
        public int? MainId { get; set; }

        [JsonIgnore]
        public virtual DbFirstTable Main { get; set; }

        public virtual ICollection<EndListTable> EndListTables { get; set; }
    }
}