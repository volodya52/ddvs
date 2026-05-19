using System;
using System.Collections.Generic;

namespace OurDecor.Models;

public partial class MaterialType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double ProcentOfBrak { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
