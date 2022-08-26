using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Team3Astro
{
    public struct setting
    {
        public static string path = @".\", filename = "",data="";

    }

    [DataContract]
    public class AstroJsonList
    {
        [DataMember]
        public string Select1 { get; set; }
        [DataMember]
        public string Select2 { get; set; }
        [DataMember]
        public string information { get; set; }
    }

    public class AstroFunction
    {
        public void WriteJson(List<AstroJsonList> list)
        {
          
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(list.GetType());
            MemoryStream ms = new MemoryStream();
            dcjs.WriteObject(ms, list);
            ms.Flush();
            setting.data= Encoding.UTF8.GetString(ms.ToArray());
      
        }
    }
}
