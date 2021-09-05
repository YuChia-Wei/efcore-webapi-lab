using System.Collections.Generic;
using Newtonsoft.Json;

#nullable disable

namespace LabWebApi.Repository.Entities
{
    public partial class EndTable
    {
        public EndTable()
        {
            SubTables = new HashSet<SubTable>();
        }

        public int EndId { get; set; }
        public string EndData { get; set; }

        [JsonIgnore]
        public virtual ICollection<SubTable> SubTables { get; set; }
    }
}