using parking_service.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace parking_service.Framework
{
    public static class ObjectExtensions
    {
        public static string SerializeObject(this object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ExceptionDetails));

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
    }
}