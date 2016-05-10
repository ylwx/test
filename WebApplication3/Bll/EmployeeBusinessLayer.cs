﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.DataAccessLayer;
using WebApplication3.Models;

namespace WebApplication3.Bll
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();

            return salesDal.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();

            salesDal.Employees.Add(e);

            salesDal.SaveChanges();

            return e;
        }
    }
}