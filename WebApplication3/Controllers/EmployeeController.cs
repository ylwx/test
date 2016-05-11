using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebApplication3.Bll;
using WebApplication3.DataAccessLayer;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult AddNew()
        {
            return View("AddNew");
        }

        public ActionResult CancelSave(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":

                    return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);

                case "Cancel":

                    return RedirectToAction("Index");
            }

            return new EmptyResult();
        }

        public ActionResult CreateEmployee()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult CreateEmployee04()
        {
            //return View("CreateEmployee04");
            return View("CreateEmployee04", new CreateEmployeeViewModel());
        }

        //
        // GET: /Test/
        public string GetString()
        {
            string a;
            a = simplemethod();
            return a;
            //return "Hello World is old now. It’s time for wassup bro ;";
        }

        //action commit
        [Authorize]
        public ViewResult Index()  //List<Employee>
        {
            EmployeeListViewModel EmployeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();

            List<Employee> Employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in Employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();

                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;

                empViewModel.Salary = emp.Salary.HasValue ? emp.Salary.ToString() : "";

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

            EmployeeListViewModel.UserName = User.Identity.Name; //New Line

            //return View("MyView", EmployeeListViewModel);
            EmployeeListViewModel.Employees = empViewModels;
            //employeeListViewModel.UserName = "Admin";-->Remove this line -->Change1
            return View("Index", EmployeeListViewModel);//-->Change View Name -->Change 2
        }

        public ViewResult Index04()  //List<Employee>
        {
            EmployeeListViewModel EmployeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();

            List<Employee> Employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in Employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();

                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;

                empViewModel.Salary = emp.Salary.HasValue ? emp.Salary.ToString() : "";

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

            //EmployeeListViewModel.UserName = "Admin";

            //return View("MyView", EmployeeListViewModel);
            EmployeeListViewModel.Employees = empViewModels;
            //employeeListViewModel.UserName = "Admin";-->Remove this line -->Change1
            return View("Index04", EmployeeListViewModel);//-->Change View Name -->Change 2
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":

                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();

                        empBal.SaveEmployee(e);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //return View("CreateEmployee");
                        return View("CreateEmployee04");
                    }

                case "Cancel":

                    return RedirectToAction("Index");
            }

            return new EmptyResult();
        }

        public ActionResult SaveEmployee1(string BtnSubmit)
        {
            Employee e = new Employee();

            e.FirstName = Request.Form["FName"];

            e.LastName = Request.Form["LName"];

            e.Salary = int.Parse(Request.Form["Salary"]);

            switch (BtnSubmit)
            {
                case "Save Employee":

                    return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);

                case "Cancel":

                    return RedirectToAction("Index");
            }

            return new EmptyResult();
        }

        public ActionResult SaveEmployee15(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":

                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();

                        empBal.SaveEmployee(e);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();

                        vm.FirstName = e.FirstName;

                        vm.LastName = e.LastName;

                        if (e.Salary.HasValue)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }

                        return View("CreateEmployee", vm); // Day 4 Change - Passing e here
                    }

                case "Cancel":

                    return RedirectToAction("Index");
            }

            return new EmptyResult();
        }

        public ActionResult SaveEmployee2(string FName, string LName, int Salary, string BtnSubmit)
        {
            Employee e = new Employee();

            e.FirstName = FName;

            e.LastName = LName;

            e.Salary = Salary;

            switch (BtnSubmit)
            {
                case "Save Employee":

                    return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);

                case "Cancel":

                    return RedirectToAction("Index");
            }

            return new EmptyResult();
        }

        [NonAction]
        public string simplemethod()
        {
            return "Hi, I am not action method";
        }
    }
}