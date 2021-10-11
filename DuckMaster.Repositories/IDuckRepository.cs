// Copyright (c) Mateusz Gienieczko.
// Licensed under the MIT license.

using System.Threading.Tasks;
using DuckMaster.Domain;
using DuckMaster.Repositories.Model;

namespace DuckMaster.Repositories
{
    /// <summary>
    /// Repository exposing CRUD operations on Ducks.
    /// </summary>
    public interface IDuckRepository
    {
        /// <summary>
        /// Get a <see cref="Duck"/> by its ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="Duck"/>.</param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     Its result will be the <see cref="Duck"/> object with given ID if it exists; otherwise null.
        /// </returns>
        Task<Duck?> GetDuckAsync(int id);

        /// <summary>
        /// Delete a <see cref="Duck"/> by its ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="Duck"/>.</param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     Its result will be true if the <see cref="Duck"/> with given ID was deleted; false if it did not exist.
        /// </returns>
        Task<bool> DeleteDuckAsync(int id);

        /// <summary>
        /// Create a new <see cref="Duck"/> based on <paramref name="properties"/>.
        /// </summary>
        /// <param name="properties"><see cref="DuckProperties"/> instance describing properties of the new <see cref="Duck"/>.</param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     Its result will be the newly created <see cref="Duck"/>.
        /// </returns>
        Task<int> CreateDuckAsync(DuckProperties properties);
    }
}
