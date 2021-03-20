using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Treinamento.Net.Dominio.Interfaces.Negocio;

namespace Treinamento.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IClienteNegocio _clienteNegocio;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IClienteNegocio clienteNegocio)
        {
            _logger = logger;
            _clienteNegocio = clienteNegocio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Carregar temperatura");
            _logger.LogDebug("Carregar LogDebug");
            _logger.LogError("Carregar LogError");
            _logger.LogTrace("Carregar LogTrace");
            _logger.LogCritical("Carregar LogCritical");

            CarregarLista();

            var rng = new Random();
            return BadRequest(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList());
        }

        [HttpGet("{id}")]
        public object ObterId(int id)
        {            
            return new
            {
                nome = "Curso de API",
                data = DateTime.Now
            };
            
        }

        private void CarregarLista()
        {
            //var texto = "a";
            try
            {
                
                for (int i = 0; i < 1000; i++)
                {
                    //int resultado = Convert.ToInt32(texto) + i;
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Erro no método CarregarLista");
                throw;
            }
            
        }
    }
}
