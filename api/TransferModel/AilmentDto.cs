using infrastructure.DataModels;

namespace Bees.TransferModel;

public class AilmentDto
{
    public int HiveId { get; set; }
    public string Name { get; set; }
    public AilmentSeverity Severity { get; set; }
    public string? Comment { get; set; }
    public bool Solved { get; set; }
}