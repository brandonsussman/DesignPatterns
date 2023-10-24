using System;
using System.Collections.Generic;

namespace BasicMVC.Models;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string? Name { get; set; }

    public string? Specieces { get; set; }

    public int? Age { get; set; }
}
