using System.Collections.Generic;

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

        public virtual DbFirstTable Main { get; set; }
        public virtual ICollection<EndListTable> EndListTables { get; set; }
    }
}