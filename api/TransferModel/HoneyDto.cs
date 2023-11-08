namespace Bees.TransferModel;

public class HoneyDto
{
    public string Name { get; set; }
    public bool Liquid { get; set; }
    public int Harvest { get; set; }
    public float Moisture { get; set; }
    public string? Comment { get; set; }
}