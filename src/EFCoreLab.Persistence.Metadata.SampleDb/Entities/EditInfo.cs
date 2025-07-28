namespace EFCoreLab.Persistence.Metadata.SampleDb.Entities;

public partial class EditInfo
{
    public int? OldId { get; set; }
    public int? NewId { get; set; }
    public int EditId { get; set; }

    public virtual OtherData New { get; set; }
    public virtual OtherData Old { get; set; }
}