using System.Linq;
using System.Xml.Linq;

namespace ABM.Application
{
    public class XMLParser
    {
        private readonly string[] CODES = new[] { "CAR", "TRV", "MWB" };

        public string[] Parse(string message)
        {
            var xml = XDocument.Parse(message);
            var references = xml
                .Descendants("Reference")
                .Where(x => CODES.Contains(x.Attribute("RefCode").Value))
                .Select(x=>x.Element("RefText").Value)
                .ToArray();

            return references;
        }
    }
}
