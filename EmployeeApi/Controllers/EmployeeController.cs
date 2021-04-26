using System;
using System.Threading.Tasks;
using EmployeeApi.Domain;
using EmployeeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly ILogger<EmployeeController> _logger;
		private readonly IEmployeeService _employeeService;

		public EmployeeController(
			ILogger<EmployeeController> logger,
			IEmployeeService employeeService)
		{
			_logger = logger;
			_employeeService = employeeService;
		}

		[Route("Employees/{employeeId}")]
		[HttpGet]
		public async Task<ActionResult<Employee>> GetEmployee(int employeeId)
		{
			try
			{
				var employee = await _employeeService.GetEmployee(employeeId);
				return Ok(employee);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception.ToString());
				return Problem("A problem has happened...");
			}
		}

		[Route("Employees/Older")]
		[HttpGet]
		public async Task<ActionResult<Employee>> GetOlderEmployee()
		{
			try
			{
				var olderEmployee = await _employeeService.GetOlderEmployee();
				return Ok(olderEmployee);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception.ToString());
				return Problem("A problem has happened...");
			}
		}
	}
}
