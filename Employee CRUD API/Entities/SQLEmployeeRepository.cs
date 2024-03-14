using Employee_CRUD_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Employee_CRUD_API.Entities
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public SQLEmployeeRepository(EmployeeDbContext context)
        {

            _context = context;
        }

        public async Task<bool> AddEmployeeData(Employee employee)
        {
            try
            {

                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                var empid = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);
                if (empid != null)
                    return await Task.FromResult(true);
                else
                    return await Task.FromResult(false);
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return await Task.FromResult(false); ;
            }

        }

        public async  Task<bool> DeleteEmployeeData(int id)
        {
            var result =  await _context.Employees
         .FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            
            else
                return await Task.FromResult(false);

        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Include(E=>E.Department).ToListAsync();
        }

        public async Task<Employee> GetEmployeeDetailsById(int id)
        {
            var emp= await _context.Employees.Include(x=>x.Department)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (emp != null)
            return await Task.FromResult(emp);
            else
                return await Task.FromResult(emp);



        }

        public async Task<Employee> UpdateEmployeeData(Employee employee)
        {

            var result = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.DepartmentId = employee.DepartmentId;
                result.PhoneNumber = employee.PhoneNumber;
                result.Salary = employee.Salary;

                _context.Update(result);
                await _context.SaveChangesAsync();
               /* result = await _context.Employees.Include(x => x.Department)
               .FirstOrDefaultAsync(x => x.Id == employee.Id);*/

                return await Task.FromResult(result);
            }

            return await Task.FromResult(result);


        }
    }
}
