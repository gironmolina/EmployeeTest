using Newtonsoft.Json;

namespace EmployeeApi.Model
{
	public class Employee
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("employee_name")]
		public string Name { get; set; }

		[JsonProperty("employee_salary")]
		public double Salary { get; set; }

		[JsonProperty("employee_age")]
		public int Age { get; set; }

		[JsonProperty("profile_image")]
		public string Image { get; set; }
	}
}
