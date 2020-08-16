using System.Data;
using WebDataAccess;

namespace WebService
{
    public class EmployeeService
    {
        public EmployeeRepository employeeRepository = null;
        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }
        public DataTable GetEmployees()
        {
            return employeeRepository.GetEmployees();
        }

        public DataTable GetByEmployeeId(int employeeId)
        {
            return employeeRepository.GetByEmployeeId(employeeId);
        }
    }
}
