using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Models.ViewModels
{
    public class CreateUserViewModel
    {

        public Employee EmployeeAdd { get; set; }
        public Customer CustomerAdd { get; set; }
    }
}
