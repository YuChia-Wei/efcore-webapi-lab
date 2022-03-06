#nullable disable
using System.Collections.Generic;

namespace LabWebApi.Repository.Entities
{
    public partial class OtherDatum
    {
        public OtherDatum()
        {
            EditInfoNews = new HashSet<EditInfo>();
            EditInfoOlds = new HashSet<EditInfo>();
        }

        public int OtherId { get; set; }
        public string Data { get; set; }

        public virtual ICollection<EditInfo> EditInfoNews { get; set; }
        public virtual ICollection<EditInfo> EditInfoOlds { get; set; }
    }
}