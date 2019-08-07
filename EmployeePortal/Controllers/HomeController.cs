using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeePortal.Models;
using ServicesLibrary;
using Model;

namespace EmployeePortal.Controllers
{
    public class HomeController : Controller
    {
        protected readonly EmployeeService EmployeeService;
        public HomeController(EmployeeService employeeService)
        {
            this.EmployeeService = employeeService;
        }

        public IActionResult Index()
        {
            EmployeeViewModel viewModel = new EmployeeViewModel();
            viewModel.IdFilter = string.Empty;
            List<Employee> Employees = this.EmployeeService.GetEmployees();
            Employees.ForEach(x =>
            {
                x.AnnualSalary = this.EmployeeService.CalculateSalary(x.id);
            });
            viewModel.Employees = Employees;
            return View(viewModel);
        }

        public IActionResult GetEmployee(EmployeeViewModel model)
        {
            if (!string.IsNullOrEmpty(model.IdFilter))
            {
                int outValue;
                if (int.TryParse(model.IdFilter, out outValue))
                {
                    if (ModelState.IsValid)
                    {
                        EmployeeViewModel viewModel = new EmployeeViewModel();
                        List<Employee> Employees = this.EmployeeService.GetEmployees().Where(x => x.id == outValue).ToList();
                        Employees.ForEach(x =>
                        {
                            x.AnnualSalary = this.EmployeeService.CalculateSalary(x.id);
                        });
                        viewModel.Employees = Employees;
                        viewModel.IdFilter = string.Empty;
                        return View("Index", viewModel);
                    }
                }
            }
           return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
