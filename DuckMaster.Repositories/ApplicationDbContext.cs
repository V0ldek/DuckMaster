// Copyright (c) Mateusz Gienieczko.
// Licensed under the MIT license.

using DuckMaster.Domain;
using Microsoft.EntityFrameworkCore;

namespace DuckMaster.Repositories
{
    /// <summary>
    ///     <see cref="DbContext"/> for <see cref="Duck"/> entities.
    /// </summary>
    public sealed class ApplicationDbContext : DbContext
    {
        /// <summary>
        ///     Gets the <see cref="DbSet{TEntity}"/> of all <see cref="Duck"/> entities.
        /// </summary>
        public DbSet<Duck> Ducks { get; init; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
    }
}
