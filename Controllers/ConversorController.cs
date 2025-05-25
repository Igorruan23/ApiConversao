using APIConversao.Models;
using APIConversao.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIConversao.Controllers
{
    public class ConversorController : Controller
    {
        private readonly LenghtConversorService _converter;

        public ConversorController()
        {
            _converter = new LenghtConversorService();
        }

        [Authorize]
        [HttpPost("Length")]
        public IActionResult ConvertLenght([FromBody] ConversorModel request)
        {
            try
            {
                var result = _converter.Convert(request.Value, request.FromUnit.ToLower(), request.ToUnit.ToLower());
                return Ok(new { original = request, convertedValue = result });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
