using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Models
{
    public class EmployeeDepartmentViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public string DepartmentName { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public int DepartmentId { get; set; }

        public List<SelectListItem> Data { get; set; }
    }
}