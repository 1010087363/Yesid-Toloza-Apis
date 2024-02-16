using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ejer3.Controllers
{
    public class Employee
    {
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        public required string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Las horas de trabajo deben ser un número entero positivo.")]
        public int HoursWorked { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El valor de pago por hora debe ser un número entero positivo.")]
        public decimal HourlyRate { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class CalcularSueldo : ControllerBase
    {
        [HttpGet("{name}/{hoursWorked}/{hourlyRate}")]
        public ActionResult<object> CalculateSalary(string name, int hoursWorked, decimal hourlyRate)
        {
            if (string.IsNullOrEmpty(name) || hoursWorked <= 0 || hourlyRate <= 0)
            {
                return BadRequest("Los parámetros de entrada son inválidos.");
            }

            decimal salary = hoursWorked * hourlyRate;

            return Ok(salary);
        }
    }
}
