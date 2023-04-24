using CrudOperation.Data;
using CrudOperation.Interface;
using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudOperation.Helper;
using System.Threading.Tasks;

namespace CrudOperation.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool EmployeeDelete(int employeeId)
        {
            using (EMSEntities eMS = new EMSEntities())
            {
                var myResult = eMS.Employees.Where(y=> y.ID == employeeId).FirstOrDefault();

                eMS.Employees.Remove(myResult);

               var my = eMS.SaveChanges() > 0? true : false;

                return my;
            }
        }

        public EmployeeDepartmentViewModel GetEmployeeById(int employeeId)
        {
            using (EMSEntities eMS = new EMSEntities())
            {
                var myResult = eMS.Employees.Where(y=>y.ID == employeeId).FirstOrDefault();



                return myResult.ToViewModel();
            }
        }

        public List<EmployeeDepartmentViewModel> GetEmployeeInfo()
        {
            List<EmployeeDepartmentViewModel> employees = new List<EmployeeDepartmentViewModel>();
            using (EMSEntities ems = new EMSEntities())
            {
                var myresult = ems.Employees.ToList();
                var myDepartment = ems.Depts.ToList();

                employees = myresult.Join(myDepartment, y => y.DepartmentID, x => x.ID, (x, y) => new EmployeeDepartmentViewModel()
                {
                    City = x.City,
                    State = x.State,
                    ZipCode = x.ZipCode,
                    FullName = x.FirstName + " " + x.LastName,
                    EmployeeId = x.ID,
                    DepartmentId = x.DepartmentID.Value,
                    DepartmentName = y.DepartmentName
                }).ToList();
            }
            return employees;

        }

        public bool InsertUpdateEmployeeInfo(EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {
            using (EMSEntities ems = new EMSEntities())
            {
                if (employeeDepartmentViewModel.EmployeeId == 0)
                {
                    var myResult = ems.Employees.Add(employeeDepartmentViewModel.ToViewModel());

                    var myRes = ems.SaveChanges();

                    return myRes > 0 ? true : false;
                }
                else
                {
                    var myme = ems.Employees.Where(y=> y.ID == employeeDepartmentViewModel.EmployeeId).FirstOrDefault();

                    myme.State = employeeDepartmentViewModel.State;
                    myme.ZipCode = employeeDepartmentViewModel.ZipCode;
                    myme.City = employeeDepartmentViewModel.City;
                    myme.FirstName = employeeDepartmentViewModel.FirstName;
                    myme.LastName = employeeDepartmentViewModel.LastName;
                    myme.DepartmentID = employeeDepartmentViewModel.DepartmentId;

                    return ems.SaveChanges() > 0 ? true : false;
                }
            }
        }
    }
}