using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullaBool
{
    /// <summary>
    /// We wanted to preserve the sanctity of NullaBool, plus extensions are fun. It makes you feel like a hacker!
    /// </summary>
    public static class NullaBoolExtensions
    {
        /// <summary>
        /// Unsupported converter for boring bool. Please don't contact NullaBool Corporate Headquarters if you have problems.
        /// </summary>
        /// <param name="nb"></param>
        /// <returns></returns>
        public static bool ToBool(this NullaBool nb)
        {
            if (nb.IsTrue) return true;

            if (!nb.IsFalse) throw new NullaBoolException();

            return false;
        }

        /// <summary>
        /// Unsupported converter for nullable bool. We will pretend this doesn't exist if you ask us about it.
        /// </summary>
        /// <param name="nb"></param>
        /// <returns></returns>
        public static bool? ToBoolQuestionMark(this NullaBool nb)
        {
            if (nb.IsTrue) return new bool?(true);
            if (nb.IsFalse) return new bool?(false);
            if (nb.IsNull) return null;

            throw new NullaBoolException();
        }

        /// <summary>
        /// An extremely useful extension method. Scott Hanselman dedicated an entire podcast episode to explaining this one.
        /// </summary>
        /// <param name="nb"></param>
        /// <returns></returns>
        public static object ToNull(this NullaBool nb)
        {
            return null;
        }
    }
}
