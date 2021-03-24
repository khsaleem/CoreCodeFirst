using coreRepo.Data;
using coreRepo.Infrastructure;
using coreRepo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreRepo.Service
{
    public class EmployeeRepo : IEmployee
    {
        private EmployeeContext _context;

        public EmployeeRepo(EmployeeContext context)
        {
            _context = context;
        }
        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public List<Employee> GelAll()
        {
            return _context.Employees.FromSql("select * from Employees").ToList();
            //return _context.Employees.ToList();
        }

        public Employee GetById(int Id)
        {
            return _context.Employees.FromSql("select * from Employees where id = {0}",Id).FirstOrDefault();
            //return _context.Employees.FromSql($"select * from Employees where id = {Id}").FirstOrDefault();
            //return _context.Employees.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }
    }
}
