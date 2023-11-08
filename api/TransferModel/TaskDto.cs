namespace Bees.TransferModel;

public class TaskDto
{
    public int HiveId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool Done { get; set; }
}