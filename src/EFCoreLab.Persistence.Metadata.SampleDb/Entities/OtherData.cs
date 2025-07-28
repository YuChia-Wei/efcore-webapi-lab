using System.Collections.Generic;

namespace EFCoreLab.Persistence.Metadata.SampleDb.Entities;

public partial class OtherData
{
    public OtherData()
    {
        this.EditInfoNews = new HashSet<EditInfo>();
        this.EditInfoOlds = new HashSet<EditInfo>();
    }

    public int OtherId { get; set; }
    public string Data { get; set; }

    public virtual ICollection<EditInfo> EditInfoNews { get; set; }
    public virtual ICollection<EditInfo> EditInfoOlds { get; set; }
}