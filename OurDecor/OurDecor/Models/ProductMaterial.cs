using System;
using System.Collections.Generic;

namespace OurDecor.Models;

public partial class ProductMaterial
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdMaterial { get; set; }

    public double NeobColMaterial { get; set; }

    public virtual Material IdMaterialNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
