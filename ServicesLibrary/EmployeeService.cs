using ApiRepository.Api;
using Model;
using Models.EntityModels;
using ServicesLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesLibrary
{
    public class EmployeeService
    {
        protected readonly EmployeeRepository EmployeeRepository;
        private static string ApiUrl = "api/Employees";

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }


        public List<Employee> GetEmployees()
        {
            var employees = this.EmployeeRepository.MakeGetAPICall<List<Employee>>(ApiUrl);           
            return employees;
        }

        public Employee GetEmployee(int idEmployee)
        {
            return this.GetEmployees().FirstOrDefault(x => x.id == idEmployee);
        }

        public decimal? CalculateSalary(int idEmployee)
        {
            var employee = this.GetEmployees().FirstOrDefault(x => x.id == idEmployee);
            if (employee == null)
            {
                return null;
            }
            IPayrollCalculator payrollCalculator;
            PayrollFactory factory = new PayrollFactory();
            if (employee.contractTypeName == ContractType.MonthlySalaryEmployee.ToString())
            {
                MonthlyContractDTO monthlyContract = new MonthlyContractDTO()
                {
                    Salary = employee.monthlySalary
                };
                payrollCalculator = factory.Create(monthlyContract);
                return payrollCalculator.CalculateSalary(monthlyContract);
            }
            else
            {
                HourlyContractDTO hourlyContract = new HourlyContractDTO()
                {
                    Salary = employee.hourlySalary
                };
                payrollCalculator = factory.Create(hourlyContract);
                return payrollCalculator.CalculateSalary(hourlyContract);
            }
        }

    }
}
