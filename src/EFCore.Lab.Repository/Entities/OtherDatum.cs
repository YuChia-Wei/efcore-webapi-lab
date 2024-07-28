using System.Collections.Generic;

namespace EFCore.Lab.Repository.Entities
{
    public partial class OtherDatum
    {
        public OtherDatum()
        {
            this.EditInfoNews = new HashSet<EditInfo>();
            this.EditInfoOlds = new HashSet<EditInfo>();
        }

        public int OtherId { get; set; }
        public string Data { get; set; }

        public virtual ICollection<EditInfo> EditInfoNews { get; set; }
        public virtual ICollection<EditInfo> EditInfoOlds { get; set; }
    }
}