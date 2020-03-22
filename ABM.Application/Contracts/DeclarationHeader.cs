using System.Runtime.Serialization;

namespace ABM.Application.Contracts
{
    [DataContract]
    public class DeclarationHeader
    {
        [DataMember]
        public string Jurisdiction { get; set; }

        [DataMember]
        public string CWProcedure { get; set; }

        [DataMember]
        public string DeclarationDestination { get; set; }

        [DataMember]
        public string DocumentRef { get; set; }

        [DataMember]
        public string SiteID { get; set; }

        [DataMember]
        public string AccountCode { get; set; }
    }
}
