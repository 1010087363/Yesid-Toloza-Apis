using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ejer3.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CalcularPromedioFinal : ControllerBase
    {
        [HttpGet("{parcial1}/{parcial2}/{parcial3}/{examenParcial}/{trabajoFinal}")]
        public ActionResult<object> CalculateGrade(int parcial1, int parcial2, int parcial3, int examenParcial, int trabajoFinal)
        {
            if (parcial1 <= 0 || parcial2 <= 0 || parcial3 <= 0 || examenParcial <= 0 || trabajoFinal <= 0)
            {
                return BadRequest("Las calificaciones deben ser enteros y positivos mayores que cero");
            }

            double promedioParciales = (parcial1 + parcial2 + parcial3) / 3;
            double promedioFinal = (promedioParciales * 0.55) + (examenParcial * 0.30) + (trabajoFinal * 0.15);

            promedioFinal = Math.Round(promedioFinal, 3);

            return Ok(promedioFinal);
        }
    }
}

