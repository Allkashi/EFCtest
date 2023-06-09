using System;
using System.Collections.Generic;

namespace EFCoreTest;

/// <summary>
/// Должность
/// </summary>
public partial class Job
{
    /// <summary>
    /// Идентификатор должности
    /// </summary>
    public int JobId { get; set; }

    /// <summary>
    /// Наименование должности
    /// </summary>
    public string? PosName { get; set; }

    /// <summary>
    /// Зарплата
    /// </summary>
    public int? Salary { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
