using System.Collections.Generic;

namespace DuckMaster.Domain
{
    public class Duck
    {
        public int Id { get; private init; }

        public string Name { get; private init; } = null!;

        public static Duck CreateFrom(string name)
        {
            // Validation should be here, but I'm low on time.

            return new Duck
            {
                Name = name
            };
        }
    }
}
