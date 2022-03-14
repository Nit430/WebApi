using System;
using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<EmployeeModel> employeeModels = new List<EmployeeModel>();
        public int AddEmployee(EmployeeModel employee)
        {
            employee.ID = employeeModels.Count + 1;
            employeeModels.Add(employee);

            return employee.ID;
        }
        public List<EmployeeModel> getEmployeeList()
        {
            return employeeModels;
        }

        public string getName()
        {
            return "Hello from Employee";
        }
    }
}
