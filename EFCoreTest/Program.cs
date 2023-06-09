using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                        // Сперва получим Id необходимого отдела
                        var depid = db.Departments.FirstOrDefault(d => d.DepName == "Отдел сбыта");
                        // Получаем список всех работников, которые состоят в отделе сбыта
                        var empl = (from Employee in db.Employees
                                    where Employee.DepId == depid.DepId
                                    select Employee).ToList();
                        Console.WriteLine("Список работников:");
                        // Вызываем объект класса Employee и в цикле выводиим id, имена и дату трудоустройства всех работников
                        foreach (Employee e in empl)
                        {
                            Console.WriteLine($"{e.EmpId}.{e.EmpName} - {e.DateIn} (дата трудоустройства)");
                        }
            */

            // Создаем экземпляр класса контекста
            ExamContext db = new ExamContext();
            // Заполняем информацию о новом работнике
            var Newuser = new Employee
            {
                EmpName = "Мартынов",
                JobId = 5,
                Manager = 5,
                DateIn = new DateOnly(2000, 1, 1),
                Bonus = 5,
                DepId = 5
            };
            // Находим работника для увольнения по его фамилии
            var Deluser = db.Employees.FirstOrDefault(u => u.EmpName == "Чулкова");

            if (Deluser != null)
            {
                //Выполняем операции удаления старого и сохранения нового работника
                db.Employees.Remove(Deluser);
                db.Employees.Add(Newuser);
                // Сохраняем изменения
                db.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}