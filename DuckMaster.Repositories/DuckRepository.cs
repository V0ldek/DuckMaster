// Copyright (c) Mateusz Gienieczko.
// Licensed under the MIT license.

using System.Threading.Tasks;
using DuckMaster.Domain;
using DuckMaster.Repositories.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DuckMaster.Repositories
{
    /// <inheritdoc/>
    public sealed class DuckRepository : IDuckRepository
    {
        private ILogger<DuckRepository> _logger;

        private ApplicationDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DuckRepository"/> class.
        /// </summary>
        /// <param name="dbContext"><see cref="ApplicationDbContext"/> to use for CRUD operations on Ducks.</param>
        /// <param name="logger"><see cref="ILogger{T}"/> instance to use for logging.</param>
        public DuckRepository(ApplicationDbContext dbContext, ILogger<DuckRepository> logger) =>
            (_dbContext, _logger) = (dbContext, logger);

        /// <inheritdoc/>
        public async Task<Duck?> GetDuckAsync(int id)
        {
            _logger.LogInformation("Performing Select operation for a Duck with ID '{ID}'.", id);

            var duck = await _dbContext.Ducks.AsNoTracking().SingleOrDefaultAsync(d => d.Id == id)
                .ConfigureAwait(false);

            if (duck is null)
            {
                _logger.LogInformation("Duck with ID '{ID}' not found.", id);
            }
            else
            {
                _logger.LogInformation("Duck with ID '{ID}' found.", id);
            }

            return duck;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteDuckAsync(int id)
        {
            _logger.LogInformation("Performing Delete operation on Duck with ID '{ID}'.", id);

            var duck = await _dbContext.Ducks.SingleOrDefaultAsync(d => d.Id == id).ConfigureAwait(false);

            if (duck is null)
            {
                _logger.LogInformation("Duck with ID '{ID}' not found, Delete failed.", id);

                return false;
            }

            _logger.LogInformation("Duck with ID '{ID}' found, performing Delete.", id);

            _dbContext.Ducks.Remove(duck);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("Successfully deleted Duck with ID '{ID}'", id);

            return true;
        }

        /// <inheritdoc/>
        public async Task<int> CreateDuckAsync(DuckProperties properties)
        {
            // This depends on DuckProperties having an overloaded ToString which I had no time to implement.
            _logger.LogInformation("Performing Insert operation for Duck with properties {Properties}", properties);

            var duck = Duck.CreateFrom(properties.Name);

            _dbContext.Ducks.Add(duck);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            _logger.LogInformation("Successfully created a new Duck with ID '{ID}'", duck.Id);

            return duck.Id;
        }
    }
}
