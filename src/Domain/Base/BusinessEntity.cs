using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot.Domain.Base;

public class BusinessEntity : BaseEntity
{
    public string Code { get; set; } = default!;

    public DateTime? CreateTime { get; set; } = DateTime.Now;
    public DateTime? UpdateTime { get; set; } = DateTime.Now;

    public Guid? CreateUserId { get; set; }
    public Guid? UpdateUserId { get; set; }
}
