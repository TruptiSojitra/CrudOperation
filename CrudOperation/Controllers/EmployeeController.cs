using CrudOperation.Concrete;
using CrudOperation.Interface;
using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();

            var myResult = employeeRepository.GetEmployeeInfo();

            return View(myResult);
        }

        public ActionResult Create()
        {
           EmployeeDepartmentViewModel employeeDepartmentViewModel = new EmployeeDepartmentViewModel();
            
            IDepartmentRepository departmentRepository = new DepartmentRepository();

            employeeDepartmentViewModel.Data = departmentRepository.GetDepartment();

            return View(employeeDepartmentViewModel);
        }

        public ActionResult EditEmployee(int employeeId)
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();

            IDepartmentRepository departmentRepository = new DepartmentRepository();

            var myResult = employeeRepository.GetEmployeeById(employeeId);

            myResult.Data = departmentRepository.GetDepartment();

            return View("Create", myResult);
        }

        [HttpPost]
        public ActionResult Create(EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();

            var myResult = employeeRepository.InsertUpdateEmployeeInfo(employeeDepartmentViewModel);

            if (myResult)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult DeleteEmployee(int employeeId)
        {
            IEmployeeRepository employeeRepository =new EmployeeRepository();

            var r =  employeeRepository.EmployeeDelete(employeeId);

            return RedirectToAction("Index");
        } 
    }
}