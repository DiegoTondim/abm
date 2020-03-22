using ABM.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABM.Application
{
    public class EDIFACTParser
    {
        private const char LINE_DELIMITER = '\'';
        private const char SEGMENT_DELIMITER = '+';
        private const string LOC_IDENTIFIER = "LOC";

        public IEnumerable<LocModel> Parse(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("message is invalid");
            }

            var allLines = message
                .Replace("\r\n", string.Empty)
                .Split(LINE_DELIMITER);

            return allLines
                .Where(x => x.Trim().StartsWith(LOC_IDENTIFIER))
                .Select(ParseLocFromString)
                .ToList();
        }

        private static LocModel ParseLocFromString(string line)
        {
            var segments = line.Split(SEGMENT_DELIMITER);
            if (segments == null || segments.Count() < 3)
            {
                throw new InvalidOperationException("invalid LOC item");
            }
            return new LocModel(segments[1], segments[2]);
        }
    }
}
