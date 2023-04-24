using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CrudOperation.Interface
{
    /// <summary>
    /// this is department data layer
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// this will get department data
        /// </summary>
        /// <returns>this will return lit of department</returns>
         List<SelectListItem> GetDepartment();
    }
}
