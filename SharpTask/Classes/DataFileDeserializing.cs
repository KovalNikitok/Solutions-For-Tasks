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
            string resourcePath = "SharpTask.data.json";// внутренний путь до json файла в проекте
            string dataJson = ""; // строка для получения json
            try
            {
                using (Stream thisStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
                using (StreamReader streamReader = new StreamReader(thisStream))// запускаем потоки для чтения из json файла в проекте
                {
                    dataJson = streamReader.ReadToEnd();// считываем всё содержимое файла
                }
                DataItem data = JsonConvert.DeserializeObject<DataItem>(dataJson);// конвертируем json-строку в модель данных DataItem
                return data;
            }
            catch(Exception err)
            {// если на каком-либо этапе считывания/преобразования из Json файла возникли проблемы, то выходим из try - блока и выдаём сообщение об ошибке
                throw new Exception("Не удалось десериализовать json, ошибка: "+ err);
            }
        }
    }
}
