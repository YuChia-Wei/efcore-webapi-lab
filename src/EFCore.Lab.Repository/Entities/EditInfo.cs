namespace EFCore.Lab.Repository.Entities
{
    public partial class EditInfo
    {
        public int? OldId { get; set; }
        public int? NewId { get; set; }
        public int EditId { get; set; }

        public virtual OtherDatum New { get; set; }
        public virtual OtherDatum Old { get; set; }
    }
}