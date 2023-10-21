namespace infrastructure.DataModels;

public class Honey
{
    public string Name { get; set; }
    public HoneyType Type { get; set; }
    public bool Liquid { get; set; }
    public string Flowers { get; set; }
    public DateTime HarvestTime { get; set; }
    public string? Comment { get; set; }
}