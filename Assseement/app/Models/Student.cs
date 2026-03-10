using System;
using System.Collections.Generic;

namespace app.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public int? HostelId { get; set; }

    public virtual Hostel? Hostel { get; set; }
}
