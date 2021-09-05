using System.Collections.Generic;

#nullable disable

namespace LabWebApi.Repository.Entities
{
    public partial class SubTable
    {
        public SubTable()
        {
            DbFirstTables = new HashSet<DbFirstTable>();
        }

        public int SubId { get; set; }
        public string SubData { get; set; }
        public int? EndId { get; set; }

        public virtual EndTable End { get; set; }
        public virtual ICollection<DbFirstTable> DbFirstTables { get; set; }
    }
}