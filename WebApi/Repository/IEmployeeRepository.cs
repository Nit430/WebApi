using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Repository
{
    public interface IEmployeeRepository
    {
        int AddEmployee(EmployeeModel employee);
        List<EmployeeModel> getEmployeeList();
        string getName();
    }
}