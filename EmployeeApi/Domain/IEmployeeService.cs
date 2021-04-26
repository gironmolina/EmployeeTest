using System.Threading.Tasks;
using EmployeeApi.Model;

namespace EmployeeApi.Domain
{
	public interface IEmployeeService
	{
		Task<Employee> GetEmployee(int employeeId);
		
		Task<Employee> GetOlderEmployee();
	}
}
