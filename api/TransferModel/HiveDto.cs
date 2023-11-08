using infrastructure.DataModels;

namespace Bees.TransferModel;

public class HiveDto
{
    public int FieldId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime PlacementDate { get; set; }
    public DateTime LastCheck { get; set; }
    public bool ReadyToHarvest { get; set; }
    public Ailment[] Ailments { get; set; }
    public string Color { get; set; }
    public infrastructure.DataModels.Task[] Tasks { get; set; }
    public Bee Bees { get; set; }
    public string? Comment { get; set; }
}