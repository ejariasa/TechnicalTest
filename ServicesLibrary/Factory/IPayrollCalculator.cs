using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLibrary.Factory
{
    public interface IPayrollCalculator
    {
       decimal CalculateSalary(EmployeeSalaryDTO employeeSalary);
    }
}
