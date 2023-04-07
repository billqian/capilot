using Pilot.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot.Domain.Items;

public class ItemCreatedEvent : BaseEvent
{
    public ItemCreatedEvent(Item im)
    {
        Item = im;
    }

    public Item Item { get; }
}
