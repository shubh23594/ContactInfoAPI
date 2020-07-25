using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ContactInformationAPI.Common.DTO
{
    [Serializable]
    [DataContract]
    public class Response
    {
        [DataMember(EmitDefaultValue =false)]
        public List<Contact> Contact;
        [DataMember(EmitDefaultValue = false)]
        public ResponseMetaDto ResponseMetaData;
    }
}
