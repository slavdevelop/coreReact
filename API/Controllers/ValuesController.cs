using System.Collections.Generic;
using System.Threading.Tasks;

using Domain;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(DataContext context, ILogger<ValuesController> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            this._logger.LogInformation(123, "9999999999999");
            var values = await this._context.Values.ToListAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var value = await this._context.Values.FindAsync(id);

            return Ok(value);
        }
    }
}