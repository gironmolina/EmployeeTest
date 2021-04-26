using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApi.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EmployeeApi.Domain
{
	public class EmployeeService : IEmployeeService
	{
		private readonly ILogger<EmployeeService> _logger;
		private readonly IConfiguration _configuration;
		private List<Employee> _employees;

		public EmployeeService(ILogger<EmployeeService> logger,
			IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			LoadEmployeeJson();
		}

		private void LoadEmployeeJson()
		{
			try
			{
				var jsonPath = _configuration["JsonPath"];
				var jsonFile = File.ReadAllText(jsonPath);
				var employeeResult = JsonConvert.DeserializeObject<EmployeeResult>(jsonFile);
				_employees = employeeResult?.Data;
			}
			catch (Exception exception)
			{
				_logger.LogError( $"Error Loading Employee Json - Exception: {exception}");
				throw;
			}
		}

		public async Task<Employee> GetEmployee(int employeeId)
		{
			var employee = await Task.Run(() => _employees.FirstOrDefault(i => i.Id == employeeId));
			return employee;
		}

		public async Task<Employee> GetOlderEmployee()
		{
			var olderEmployee = await Task.Run(() => _employees.OrderByDescending(i => i.Age).FirstOrDefault());
			return olderEmployee;
		}
	}
}
