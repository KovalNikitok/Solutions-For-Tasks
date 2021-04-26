using Newtonsoft.Json;
using SharpTask.Models;
using System;
using System.IO;
using System.Text;

namespace SharpTask.Classes
{
    public class DataSerialized
    {
        public void SaveData(DataItem data)
        {// Метод для сериализации получаемого POST-запросом json текста в создаваемый здесь же файл формата .json
            StringBuilder fileName = new StringBuilder("");// формируем имя файла
            fileName.Append(DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".json");
            string dataSerialize;
            try
            {// сериализуем объект в строку json формата
                dataSerialize = JsonConvert.SerializeObject(data); 
            }
            catch (Exception err)
            {// если на каком-либо этапе преобразования в из json в строку возникли проблемы, то выходим из try - блока и выдаём сообщение об ошибке
                throw new Exception("Не удалось cериализовать json, ошибка: ", err);
            } 
            try
            {// запускаем потоки для записи в файл json строки по пути проекта
                using (FileStream file = new FileStream(fileName.ToString(), FileMode.Append))
                using (StreamWriter streamWriter = new StreamWriter(file, Encoding.GetEncoding("UTF-8")))
                {// записываем строку формата json в файл
                    streamWriter.WriteLine(dataSerialize);
                }   
            }
            catch(Exception err)
            {// если на каком-либо этапе записи в файл возникает ошибка, то выходим из try - блока и выдаём сообщение об ошибке
                throw new Exception("Не удалось совершить операции с файлом, ошибка: ", err);
            }    
        }
    }
}
