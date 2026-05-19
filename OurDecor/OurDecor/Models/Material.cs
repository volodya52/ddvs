using System;
using System.Collections.Generic;

namespace OurDecor.Models;

public partial class Material
{
    public int Id { get; set; }

    public string MaterialName { get; set; } = null!;

    public int IdMaterialType { get; set; }

    public double PriceEd { get; set; }

    public double CountInWarehouse { get; set; }

    public double MinCol { get; set; }

    public int ColInUp { get; set; }

    public int EdIzm { get; set; }

    public virtual EdIzm EdIzmNavigation { get; set; } = null!;

    public virtual MaterialType IdMaterialTypeNavigation { get; set; } = null!;

    public virtual ICollection<ProductMaterial> ProductMaterials { get; set; } = new List<ProductMaterial>();
}
