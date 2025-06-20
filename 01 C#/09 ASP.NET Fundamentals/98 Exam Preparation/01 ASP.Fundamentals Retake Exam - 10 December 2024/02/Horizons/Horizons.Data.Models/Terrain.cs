using System.ComponentModel.DataAnnotations;
using Horizons.GCommon;

public class Terrain
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Destination> Destinations { get; set; }
        = new HashSet<Destination>();
}
