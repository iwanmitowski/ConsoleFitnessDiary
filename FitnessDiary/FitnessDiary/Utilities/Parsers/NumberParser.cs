using FitnessDiary.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDiary.Utilities.Parsers
{
    public static class NumberParser
    {
        public static T TryParse<T>(string value, TryParseHandler<T> handler) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidInputType);
            }

            T result;

            if (handler(value, out result))
            {
                return result;
            }

            Trace.TraceWarning("Invalid value '{0}'", value);
            throw new InvalidOperationException(ExceptionMessages.InvalidInputType);
        }

        public delegate bool TryParseHandler<T>(string value, out T result);
    }
}
