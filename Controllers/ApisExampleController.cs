using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace primerWebApiPrueba.Controllers
{

        [Route("api/")]
        [ApiController]
        public class ValuesController : ControllerBase
        {

            // GET api/hola-mundo
            [HttpGet("hola-mundo")]
            public ActionResult<string> GetHolaMundo()
            {
                return "Hola Mundo";
            }
            
            // GET https://localhost:5001/api/login; http://localhost:5000/api/login;
            [HttpGet("login")]
            public IActionResult Login()
            {
                // Aquí iría la lógica para validar al usuario (por ejemplo, revisando el usuario en la base de datos)
                
                // Si el usuario es válido, generamos el JWT
                var tokenGenerator = new JwtTokenGenerator();
                // Le pasamos La Id del usuario y el rol
                var token = tokenGenerator.GenerateToken("H241oij1o2i3j1", "Admin");

                return Ok(new { token });
            }
        }

    
}
