// Copyright (c) Mateusz Gienieczko.
// Licensed under the MIT license.

using DuckMaster.Domain;

namespace DuckMaster.Repositories.Model
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "StyleCop does not understand records.")]

    public sealed record DuckDto(int Id, string Name)
    {
    }
}
