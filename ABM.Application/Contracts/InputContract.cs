using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ABM.Application.Contracts
{
    [DataContract]
    [XmlRoot("InputDocument")]
    public class InputContract
    {
        [DataMember]
        [XmlArray(ElementName = "DeclarationList")]
        [XmlArrayItem(ElementName = "Declaration")]
        public DeclarationContract[] DeclarationList { get; set; }
    }
}
