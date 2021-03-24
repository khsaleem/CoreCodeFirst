using coreRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreRepo.Infrastructure
{
    public interface IEmployee
    {
        List<Employee> GelAll();
        Employee GetById(int Id);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        void Save();


    }
}
