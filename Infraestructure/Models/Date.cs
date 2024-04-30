using System;
using System.Collections.Generic;

namespace Infraestructure.Models;

public partial class Date
{
    public int DateId { get; set; }

    public DateOnly? DateSchedule { get; set; }

    public int? Hours { get; set; }

    public int? TaskId { get; set; }
}
