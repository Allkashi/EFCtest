using System;
using System.Collections.Generic;

namespace EFCoreTest;

/// <summary>
/// Отдел
/// </summary>
public partial class Department
{
    /// <summary>
    /// Идентификатор отдела
    /// </summary>
    public int DepId { get; set; }

    /// <summary>
    /// Наименование отдела
    /// </summary>
    public string? DepName { get; set; }

    /// <summary>
    /// Кодовое наименование отдела
    /// </summary>
    public string? CodeDepName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
