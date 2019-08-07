using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLibrary.Factory
{
    public class PayrollMonthly : IPayrollCalculator
    {
        public decimal CalculateSalary(EmployeeSalaryDTO employeeSalary)
        {
            return employeeSalary.Salary * 12;
        }
    }
}
