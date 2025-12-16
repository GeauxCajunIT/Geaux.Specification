// // <copyright file="" company="GeauxCajunIT">
// // Copyright (c) GeauxCajunIT. All rights reserved.
// // </copyright>

namespace Geaux.Specification.Abstractions;

/// <summary>
/// Defines a contract for entities with a strongly typed identifier.
/// </summary>
/// <typeparam name="TId">The type of the identifier (int, Guid, string, etc.).</typeparam>
public interface IEntity<TId>
{
    /// <summary>
    /// Gets or sets the primary key identifier for the entity.
    /// </summary>
    TId Id { get; set; }
}


