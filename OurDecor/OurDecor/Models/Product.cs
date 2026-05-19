using System;
using System.Collections.Generic;

namespace OurDecor.Models;

public partial class Product
{
    public int Id { get; set; }

    public int IdProductType { get; set; }

    public string ProductionName { get; set; } = null!;

    public int Articul { get; set; }

    public double MinPriceForPartner { get; set; }

    public double ShirinaRulona { get; set; }

    public virtual ProductType IdProductTypeNavigation { get; set; } = null!;

    public virtual ICollection<ProductMaterial> ProductMaterials { get; set; } = new List<ProductMaterial>();
}
