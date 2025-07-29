namespace EFCoreLab.Persistence.Repositories.DataTrees.Dtos;

public class SubListTableDto
{
    public int SubId { get; set; }
    public string SubData { get; set; }
    public int? MainId { get; set; }

    public virtual ICollection<EndListTableDto> EndListTables { get; set; }
}