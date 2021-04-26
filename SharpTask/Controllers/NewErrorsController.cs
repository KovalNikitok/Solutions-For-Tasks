using Microsoft.AspNetCore.Mvc;
using SharpTask.Classes;
using SharpTask.Models;
using System;

namespace SharpTask.Controllers
{
    [Route("api/newErrors")]
    [ApiController]
    public class NewErrorsController : ControllerBase
    {


        [HttpPost]
        public string Post(DataItem data)
        {
            if(data == null)
            {
                return new string("Нет данных!");
            }
            try
            {
                DataSerialized dataToJsonFile = new DataSerialized();
                dataToJsonFile.SaveData(data);
            }
            catch(Exception err)
            {
                throw new Exception("Не удалось провести преобразование, ошибка: ",err);
            }
            return new string("OK");
        }
    }
}
