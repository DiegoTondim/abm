using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ABM.Application.Contracts
{
    [DataContract]
    public class DeclarationContract
    {
        [DataMember]
        [XmlAttribute]
        public string Command { get; set; }

        [DataMember]
        [XmlAttribute]
        public string Version { get; set; }

        [DataMember]
        public DeclarationHeader DeclarationHeader { get; set; }
    }
}
