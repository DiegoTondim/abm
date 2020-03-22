using ABM.Application;
using FluentAssertions;
using System.IO;
using Xunit;

namespace ABM.Aplication.Tests
{
    public class XMLParserTests
    {
        [Fact]
        public async void ShouldParseAMessageToAnArray()
        {
            var message = await ReadXml("Xmls/message.xml");

            var parser = new XMLParser();
            var references = parser.Parse(message);

            references.Should().NotBeNull();
            references.Should().HaveCount(3);
            references.Should().BeEquivalentTo("586133622", "71Q0019681", "1");
        }

        [Fact]
        public async void ShouldReturnEmptyArray()
        {
            var message = await ReadXml("Xmls/message-no-codes.xml");

            var parser = new XMLParser();
            var references = parser.Parse(message);
            references.Should().NotBeNull();
            references.Should().HaveCount(0);
        }

        //In order to keep it simple, I'm abstracting the readers/streams/infrastructure layer 
        //and just getting a string with the xml content also I'm considering that the file is previously validated
        private static async System.Threading.Tasks.Task<string> ReadXml(string file)
        {
            return await new StreamReader(new FileStream(file, FileMode.Open)).ReadToEndAsync();
        }
    }
}
