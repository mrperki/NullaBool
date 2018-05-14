using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullaBool
{
    /// <summary>
    /// Wow, seriously? Are you getting this exception? Why? I already warned you not to use NullaBool.
    /// </summary>
    public class NullaBoolException : Exception
    {
        public NullaBoolException() : base("Someone broke the NullaBool! Why are you even using it? Idiot.") { }

        public NullaBoolException(bool attemptedComparison) : base("Nothing compares to NullaBool!") { }

        public NullaBoolException(NullaBool value) : base(
            value.HasPumpkinSpice
            ? "Your NullaBool has pumpkin spice! You can't take the pumpkin spice away! How dare you!"
            : "You have violated the integrity of this beautiful NullaBool, you monster."
            )
        { }
    }
}
