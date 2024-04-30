using System;
using System.Collections.Generic;

namespace Infraestructure.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string? Description { get; set; }

    public DateOnly? CreateAt { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
