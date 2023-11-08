namespace Bees.TransferModel;

public class HarvestDto
{
    public int HiveId { get; set; }
    public DateTime Time { get; set; }
    public int HoneyAmount { get; set; }
    public int BeeswaxAmount { get; set; }
}