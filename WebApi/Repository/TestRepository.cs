using System;
using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Repository
{
    public class TestRepository : IEmployeeRepository
    {
        public int AddEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> getEmployeeList()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            return "Hello From Test Repository";
        }
    }
}
