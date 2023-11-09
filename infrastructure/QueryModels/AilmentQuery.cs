using infrastructure.DataModels;

namespace infrastructure.QueryModels;

public class AilmentQuery
{
    public int AilmentId { get; set; }
    public int AilmentHiveId { get; set; }
    public string AilmentName { get; set; }
    public AilmentSeverity AilmentSeverity { get; set; }
    public string? AilmentComment { get; set; }
    public bool AilmentSolved { get; set; }
}