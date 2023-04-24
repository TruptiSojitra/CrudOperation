using CrudOperation.Data;
using CrudOperation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudOperation.Helper;

namespace CrudOperation.Concrete
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public List<SelectListItem> GetDepartment()
        {
            using(EMSEntities em = new EMSEntities())
            { 
                var myResult = em.Depts.ToList().ToViewModel();
                return myResult;
            }
        }
    }
}