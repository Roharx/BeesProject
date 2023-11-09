namespace infrastructure.QueryModels;

public class HarvestQuery
{
    public int HarvestId { get; set; }
    public int HarvestHiveId { get; set; }
    public DateTime HarvestTime { get; set; }
    public int HarvestedHoneyAmount { get; set; }
    public int HarvestedBeeswaxAmount { get; set; }
}