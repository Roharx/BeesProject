namespace infrastructure.QueryModels;

public class HiveQuery
{
    public int HiveId { get; set; }
    public int HiveFieldId { get; set; }
    public string HiveName { get; set; }
    public string HiveLocation { get; set; }
    public DateTime HivePlacementDate { get; set; }//date
    public DateTime HiveLastCheck { get; set; }//timestamp
    public bool HiveReadyToHarvest { get; set; }
    public string HiveColor { get; set; }
    public int BeeId { get; set; }
    public string? HiveComment { get; set; }
}
//TODO: comments are for dev only, remove at release