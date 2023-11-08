namespace infrastructure.DataModels;
/*
 * HoneyAmount: ml
 * BeeswaxAmount: ml
 */
public class Harvest
{
    public int Id { get; set; }
    public int HiveId { get; set; }
    public DateTime Time { get; set; }
    public int HoneyAmount { get; set; }
    public int BeeswaxAmount { get; set; }
}