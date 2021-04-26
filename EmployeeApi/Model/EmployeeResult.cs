using System.Collections.Generic;

namespace EmployeeApi.Model
{
	public class EmployeeResult
	{
		public string Status { get; set; }

		public List<Employee> Data { get; set; }
	}
}
