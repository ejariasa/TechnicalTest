using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Models
{
    public class EmployeeViewModel
    {
        public List<Model.Employee> Employees { get; set; }
        public string IdFilter { get; set; }

    }
}
