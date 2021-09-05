using System.Collections.Generic;

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

        public virtual ICollection<SubTable> SubTables { get; set; }
    }
}