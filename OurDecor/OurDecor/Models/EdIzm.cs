using System;
using System.Collections.Generic;

namespace OurDecor.Models;

public partial class EdIzm
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
