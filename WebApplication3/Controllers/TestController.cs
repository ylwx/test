using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public string GetString()
        {
            string a;
            a = simplemethod();
            return a;
            //return "Hello World is old now. It’s time for wassup bro ;";
        }

        public ActionResult getView()
        {
            EmployeeListViewModel EmployeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();

            List<Employee> Employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in Employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();

                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;

                empViewModel.Salary = emp.Salary.ToString("C");

                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                //123
                empViewModels.Add(empViewModel);
            }

            EmployeeListViewModel.Employees = empViewModels;

            EmployeeListViewModel.UserName = "Admin";

            return View("MyView", EmployeeListViewModel);
        }

        [NonAction]
        public string simplemethod()
        {
            return "Hi, I am not action method";
        }
    }
}