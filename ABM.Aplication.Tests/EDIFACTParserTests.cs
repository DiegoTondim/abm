using ABM.Application;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace ABM.Aplication.Tests
{
    public class EDIFACTParserTests
    {
        [Fact]
        public void ShouldParseAMessageToAnArray()
        {
            var message = @"UNA:+.? '
                        UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-
                        IE++1++1'
                        UNH+EDIFACT+CUSDEC:D:96B:UN:145050'
                        BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'
                        LOC+17+IT044100'
                        LOC+18+SOL'
                        LOC+35+SE'
                        LOC+36+TZ'
                        LOC+116+SE003033'
                        DTM+9:20090527:102'
                        DTM+268:20090626:102'
                        DTM+182:20090527:102'";

            var parser = new EDIFACTParser();
            var arrayOfLocs = parser.Parse(message);

            arrayOfLocs.Should().NotBeNull();
            arrayOfLocs.Should().HaveCount(5);

            arrayOfLocs.First().FirstSegment.Should().Be("17");
            arrayOfLocs.First().SecondSegment.Should().Be("IT044100");
        }

        [Fact]
        public void ShouldThrowAnExceptionMessageInvalid()
        {
            var message = "";

            var parser = new EDIFACTParser();
            Action action = () => parser.Parse(message);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("message is invalid");
        }

        [Fact]
        public void ShouldThrowAnExceptionLocSegmentInvalid()
        {
            var message = @"UNA:+.? '
                        UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-
                        IE++1++1'
                        UNH+EDIFACT+CUSDEC:D:96B:UN:145050'
                        BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'
                        LOC+17'
                        LOC+18+SOL'
                        LOC+35+SE'
                        LOC+36+TZ'
                        LOC+116+SE003033'
                        DTM+9:20090527:102'
                        DTM+268:20090626:102'
                        DTM+182:20090527:102'";

            var parser = new EDIFACTParser();
            Action action = () => parser.Parse(message);

            action
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("invalid LOC item");
        }
    }
}
