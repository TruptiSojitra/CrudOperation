using CrudOperation.Data;
using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Helper
{
    static class Helper
    {
        public static Employee ToViewModel(this EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {
            Employee employee = new Employee();

            employee.City = employeeDepartmentViewModel.City;
            employee.State = employeeDepartmentViewModel.State;
            employee.ZipCode = employeeDepartmentViewModel.ZipCode;
            employee.FirstName = employeeDepartmentViewModel.FirstName;
            employee.LastName = employeeDepartmentViewModel.LastName;
            employee.DepartmentID = employeeDepartmentViewModel.DepartmentId;


            return employee;
        }

        public static SelectListItem ToViewModel(this Dept dept)
        {
            SelectListItem selectListItem = new SelectListItem();
            selectListItem.Text = dept.DepartmentName;
            selectListItem.Value = dept.ID.ToString();

            return selectListItem;
        }

        public static List<SelectListItem> ToViewModel(this List<Dept> dept)
        {
            var myResult = dept.Select(y=> y.ToViewModel()).ToList();

            return myResult;
        }

        public static EmployeeDepartmentViewModel ToViewModel(this Employee employee)
        {
            EmployeeDepartmentViewModel employeeDepartmentViewModel = new EmployeeDepartmentViewModel();

            employeeDepartmentViewModel.FirstName = employee.FirstName;
            employeeDepartmentViewModel.LastName = employee.LastName;
            employeeDepartmentViewModel.DepartmentId = employee.DepartmentID.Value;
            employeeDepartmentViewModel.City = employee.City;
            employeeDepartmentViewModel.State = employee.State;
            employeeDepartmentViewModel.ZipCode = employee.ZipCode;
            employeeDepartmentViewModel.EmployeeId = employee.ID;

            return employeeDepartmentViewModel;

        }
    }

    
}