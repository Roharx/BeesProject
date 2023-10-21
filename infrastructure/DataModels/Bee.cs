namespace infrastructure.DataModels;

public class Bee
{
    public string Name { get; set; }
    public BeeType Type { get; set; }
    public DateTime Placement { get; set; }
    public string? Comment { get; set; }
}