using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> Employees = new List<Employee>();
            Employee emp = new Employee();

            emp.FirstName = "johnson";

            emp.LastName = " fernandes";
            emp.Salary = 14000;

            Employees.Add(emp);

            emp = new Employee();

            emp.FirstName = "michael";

            emp.LastName = "jackson";

            emp.Salary = 16000;

            Employees.Add(emp);

            emp = new Employee();

            emp.FirstName = "robert";

            emp.LastName = " pattinson";

            emp.Salary = 20000;

            Employees.Add(emp);

            return Employees;
        }
    }
}