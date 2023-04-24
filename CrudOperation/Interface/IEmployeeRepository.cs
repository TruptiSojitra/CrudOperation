using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudOperation.Models;

namespace CrudOperation.Interface
{
    public interface IEmployeeRepository
    {
         List<EmployeeDepartmentViewModel> GetEmployeeInfo();

        bool InsertUpdateEmployeeInfo(EmployeeDepartmentViewModel employeeDepartmentViewModel);

        bool EmployeeDelete(int employeeId);

        EmployeeDepartmentViewModel GetEmployeeById(int employeeId);
    }
}
