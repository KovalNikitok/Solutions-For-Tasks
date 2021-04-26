using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System;

namespace SharpTask.Models
{
    public class DataFileDeserializing
    {   
        public DataItem GetData()
        {
            string resourcePath = "SharpTask.data.json";
            string dataJson = "";
            try
            {
                using (Stream thisStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
                using (StreamReader streamReader = new StreamReader(thisStream))
                {
                    dataJson = streamReader.ReadToEnd();
                }
                DataItem data = JsonConvert.DeserializeObject<DataItem>(dataJson);
                return data;
            }
            catch
            {
                throw new Exception("Не удалось десериализовать json.");
            }
        }
    }
}
