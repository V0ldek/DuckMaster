// Copyright (c) Mateusz Gienieczko.
// Licensed under the MIT license.

using System.Threading.Tasks;
using DuckMaster.Domain;
using DuckMaster.Repositories;
using DuckMaster.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DuckMaster.Controllers
{
    /// <summary>
    /// CRUD controller for Ducks.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DuckController : ControllerBase
    {
        private readonly ILogger<DuckController> _logger;
        private readonly IDuckRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DuckController"/> class.
        /// </summary>
        /// <param name="repository"><see cref="IDuckRepository"/> repository to use for CRUD operations.</param>
        /// <param name="logger"><see cref="ILogger{T}"/> instance to use for logging.</param>
        public DuckController(IDuckRepository repository, ILogger<DuckController> logger) =>
            (_repository, _logger) = (repository, logger);

        /// <summary>
        /// Retrieve a Duck by its ID.
        /// </summary>
        /// <param name="id">ID of the Duck.</param>
        /// <returns>
        ///     Result 200 with the Duck object if the Duck was found.
        ///     404 if the duck does not exist.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Duck>> Get(int id)
        {
            _logger.LogInformation("GET request for Duck with id {Id}", id);

            var duck = await _repository.GetDuckAsync(id);

            if (duck is null)
            {
                return NotFound();
            }

            return Ok(duck);
        }

        /// <summary>
        /// Create a new Duck.
        /// </summary>
        /// <param name="duck">Parameters for the Duck.</param>
        /// <returns>Result 201 with the path to the created Duck.</returns>
        [HttpPut("")]
        public async Task<ActionResult<Duck>> Put([FromBody] DuckProperties duck)
        {
            _logger.LogInformation("PUT request for Duck with properties: ");

            var id = await _repository.CreateDuckAsync(duck);

            return CreatedAtAction("Get", new { id }, new {Id = id});
        }

        /// <summary>
        /// Delete the Duck with the given ID.
        /// </summary>
        /// <param name="id">ID of the Duck.</param>
        /// <returns>
        ///     Result 204 if the Duck was successfully deleted.
        ///     404 if the duck does not exist.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("DELETE request for Duck with id {Id}", id);

            var deleted = await _repository.DeleteDuckAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
