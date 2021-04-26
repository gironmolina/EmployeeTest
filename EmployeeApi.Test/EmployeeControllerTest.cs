using System.IO;
using System.Threading.Tasks;
using EmployeeApi.Controllers;
using EmployeeApi.Domain;
using EmployeeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace EmployeeApi.Test
{
	public class Tests
	{
		private EmployeeController _sut;

		[OneTimeSetUp]
		public void Setup()
		{
			var configuration = GetConfig();
			var employeeService = new EmployeeService(new NullLogger<EmployeeService>(), configuration);
			_sut = new EmployeeController(new NullLogger<EmployeeController>(), employeeService);
		}

		[Test]
		public async Task GivenValidEmployeeId_WhenGetEmployeeGetEmployee_ThenReturnExpectedResult()
		{
			// Arrange
			var employeeId = 1;

			// Act
			var employee = await _sut.GetEmployee(employeeId);

			// Assert
			Assert.IsInstanceOf<OkObjectResult>(employee.Result);
			var okObjectResult = (OkObjectResult)employee.Result;
			Assert.IsInstanceOf<Employee>(okObjectResult.Value);
			var employeeValue = (Employee)okObjectResult.Value;
			Assert.AreEqual(1, employeeValue.Id);
			Assert.AreEqual(61, employeeValue.Age);
			Assert.AreEqual("", employeeValue.Image);
			Assert.AreEqual("Tiger Nixon", employeeValue.Name);
			Assert.AreEqual(320800, employeeValue.Salary);
		}

		[Test]
		public async Task WhenGetOlderEmployee_ThenReturnOlderEmployee()
		{
			// Act
			var employee = await _sut.GetOlderEmployee();

			// Assert
			Assert.IsInstanceOf<OkObjectResult>(employee.Result);
			var okObjectResult = (OkObjectResult)employee.Result;
			Assert.IsInstanceOf<Employee>(okObjectResult.Value);
			var employeeValue = (Employee)okObjectResult.Value;
			Assert.AreEqual(3, employeeValue.Id);
			Assert.AreEqual(66, employeeValue.Age);
			Assert.AreEqual("", employeeValue.Image);
			Assert.AreEqual("Ashton Cox", employeeValue.Name);
			Assert.AreEqual(86000, employeeValue.Salary);
		}

		private IConfiguration GetConfig()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", true, true)
				.AddEnvironmentVariables();

			return builder.Build();
		}
	}
}