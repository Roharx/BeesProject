namespace infrastructure.QueryModels;

public class BeeQuery
{
    public int BeeId { get; set; }
    public string BeeName { get; set; }
    public string BeeDescription { get; set; }
    public string? BeeComment { get; set; }
}