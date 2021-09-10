using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDapper.Models;

namespace WebApplicationDapper.Repository
{
    public interface IEmployeeRepository
    {
        Employee Find(int id);
        List<Employee> GetAll();

        Employee Add(Employee company);
        Employee Update(Employee company);

        void Remove(int id);
    }
}
