using System.Runtime.Serialization;

namespace parking_service.Models
{
    [DataContract]
    public class ExceptionDetails
    {
        [DataMember]
        public string message { get; set; }

        [DataMember]
        public string err_type { get; set; }

        [DataMember]
        public string err_code { get; set; }
    }
}