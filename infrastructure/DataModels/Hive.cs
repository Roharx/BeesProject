namespace infrastructure.DataModels;

public class Hive
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Placement { get; set; }
    public DateTime LastCheckup { get; set; }
    public string Color { get; set; }
    public Ailments[]? Ailments { get; set; }
    public string? Tasks { get; set; }
    public string? Comment { get; set; }
}