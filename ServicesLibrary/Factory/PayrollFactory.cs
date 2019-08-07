using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLibrary.Factory
{
    public class PayrollFactory
    {
        public IPayrollCalculator Create(EmployeeSalaryDTO employeeSalary)
        {
            if (employeeSalary is MonthlyContractDTO)
            {
                return new PayrollMonthly();
            }
            else
            {
                return new PayrollHourly();
            }

        }
    }
}
