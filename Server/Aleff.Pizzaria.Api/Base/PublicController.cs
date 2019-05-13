using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Aleff.Pizzaria.Api.Base
{
    [Route("api/[controller]")]
    public class PublicController : ApiControllerBase
    {
        /// <summary>
        /// Informa para o client que está ativa
        /// Útil para validar tokens e para descobrir o estado da API
        /// </summary>
        [HttpGet]
        [Route("is-alive")]
        public IActionResult IsAlive()
        {
            return Ok(true);
        }
    }
}