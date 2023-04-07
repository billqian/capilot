using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot.Domain.Items;

public class Item : BusinessEntity
{
    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public bool IsDeleted { get; set; } = false;

    public bool IsDisabled { get; set; } = false;
}
