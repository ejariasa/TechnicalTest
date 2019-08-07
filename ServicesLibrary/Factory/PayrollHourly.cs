using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLibrary.Factory
{
    public class PayrollHourly : IPayrollCalculator
    {
        public decimal CalculateSalary(EmployeeSalaryDTO employeeSalary)
        {
            return 120 * employeeSalary.Salary * 12;
        }
    }
}
