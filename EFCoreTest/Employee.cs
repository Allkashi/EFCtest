using System;
using System.Collections.Generic;

namespace EFCoreTest;

public partial class Employee
{
    /// <summary>
    /// Идентификатор сотрудника
    /// </summary>
    public int EmpId { get; set; }

    /// <summary>
    /// ФИО сотрудника
    /// </summary>
    public string? EmpName { get; set; }

    /// <summary>
    /// Идентификатор должности
    /// </summary>
    public int? JobId { get; set; }

    /// <summary>
    /// Начальник сотрудника
    /// </summary>
    public int? Manager { get; set; }

    /// <summary>
    /// Дата трудоустройства
    /// </summary>
    public DateOnly? DateIn { get; set; }

    /// <summary>
    /// Размер премии (%)
    /// </summary>
    public int? Bonus { get; set; }

    /// <summary>
    /// Идентификатор отдела
    /// </summary>
    public int? DepId { get; set; }

    public virtual Department? Dep { get; set; }

    public virtual ICollection<Employee> InverseManagerNavigation { get; set; } = new List<Employee>();

    public virtual Job? Job { get; set; }

    public virtual Employee? ManagerNavigation { get; set; }
}
