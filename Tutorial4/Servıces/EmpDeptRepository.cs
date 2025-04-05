using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tutorial3.Models;

namespace Tutorial4.Services
{
    public class EmpDeptRepository
    {
        private readonly MyDbContext _dbContext;

        public EmpDeptRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Emp> GetAllEmployees()
        {
            return _dbContext.Emps.AsNoTracking().ToList();
        }
        public Emp GetEmployeeById(int empNo)
        {
            return _dbContext.Emps.AsNoTracking().FirstOrDefault(e => e.EmpNo == empNo);
        }
        public List<Emp> GetEmployeesWithSalaryGreaterThan(decimal minSal)
        {
            return _dbContext.Emps.AsNoTracking()
                                  .Where(e => e.Sal > minSal)
                                  .ToList();
        }
        public int GetEmployeeCount()
        {
            return _dbContext.Emps.AsNoTracking().Count();
        }
        public List<Emp> GetEmployeesByDept(int deptNo)
        {
            return _dbContext.Emps.AsNoTracking()
                                  .Where(e => e.DeptNo == deptNo)
                                  .ToList();
        }
        public List<dynamic> GetEmployeeDeptJoin()
        {
            var query = from e in _dbContext.Emps.AsNoTracking()
                        join d in _dbContext.Depts.AsNoTracking() on e.DeptNo equals d.DeptNo
                        select new { e.EName, d.DName };
            return query.ToList<dynamic>();
        }
        public List<dynamic> GetEmployeeCountByDept()
        {
            var query = _dbContext.Emps.AsNoTracking()
                        .GroupBy(e => e.DeptNo)
                        .Select(g => new { DeptNo = g.Key, EmployeeCount = g.Count() });
            return query.ToList<dynamic>();
        }
        public List<Emp> GetTopNHighestPaidEmployees(int n)
        {
            return _dbContext.Emps.AsNoTracking()
                                  .OrderByDescending(e => e.Sal)
                                  .Take(n)
                                  .ToList();
        }
        public List<Dept> GetDepartmentsWithNoEmployees()
        {
            return _dbContext.Depts.AsNoTracking()
                                   .Where(d => !_dbContext.Emps.AsNoTracking().Any(e => e.DeptNo == d.DeptNo))
                                   .ToList();
        }
        public decimal GetAverageSalary()
        {
            return _dbContext.Emps.AsNoTracking().Average(e => e.Sal);
        }
        public decimal GetMaxSalary()
        {
            return _dbContext.Emps.AsNoTracking().Max(e => e.Sal);
        }
        public decimal GetMinSalary()
        {
            return _dbContext.Emps.AsNoTracking().Min(e => e.Sal);
        }
        public List<Emp> GetEmployeesOrderedByName()
        {
            return _dbContext.Emps.AsNoTracking()
                                  .OrderBy(e => e.EName)
                                  .ToList();
        }
        public List<Emp> GetEmployeesHiredWithinDateRange(DateTime start, DateTime end)
        {
            return _dbContext.Emps.AsNoTracking()
                                  .Where(e => e.HireDate >= start && e.HireDate <= end)
                                  .ToList();
        }
        public List<Emp> GetEmployeesByNamePrefix(string prefix)
        {
            return _dbContext.Emps.AsNoTracking()
                                  .Where(e => e.EName.StartsWith(prefix))
                                  .ToList();
        }
        public decimal GetTotalSalaryByDept(int deptNo)
        {
            return _dbContext.Emps.AsNoTracking()
                                  .Where(e => e.DeptNo == deptNo)
                                  .Sum(e => e.Sal);
        }
        public List<string> GetDistinctJobTitles()
        {
            return _dbContext.Emps.AsNoTracking()
                                  .Select(e => e.Job)
                                  .Distinct()
                                  .ToList();
        }
        public bool DoesEmployeeExistByName(string name)
        {
            return _dbContext.Emps.AsNoTracking().Any(e => e.EName == name);
        }
        public Emp GetFirstHiredEmployeeInDept(int deptNo)
        {
            return _dbContext.Emps.AsNoTracking()
                                  .Where(e => e.DeptNo == deptNo)
                                  .OrderBy(e => e.HireDate)
                                  .FirstOrDefault();
        }
        public Emp GetLastHiredEmployeeInDept(int deptNo)
        {
            return _dbContext.Emps.AsNoTracking()
                                  .Where(e => e.DeptNo == deptNo)
                                  .OrderByDescending(e => e.HireDate)
                                  .FirstOrDefault();
        }
    }
}

