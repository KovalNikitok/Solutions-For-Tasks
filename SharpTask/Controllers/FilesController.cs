using Microsoft.AspNetCore.Mvc;
using SharpTask.Models;
using SharpTask.Models.DataInfo;
using System.Collections.Generic;
using System.Web.Http;

namespace SharpTask.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/filenames/{result?}")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        public List<string> Get([FromUri]bool correct)
        {
            FilesInfo[] files = new DataFileDeserializing().GetData().Files; //получаем десериализованный Json
            List<string> fList = new List<string>(); // строка для формирования овтета
            if (correct)
            {// условия в рамках запроса api/filenames?correct={value}, где value = true/false
                for (int index = 0; index < files.Length; index++)
                {// для получения результатов проходим по всему массиву объектов files и отбираем в список лишь то, что соответствует нашему условию
                    if (files[index].result)
                    {
                        fList.Add(files[index].filename);
                    } 
                }
            }
            else if (!correct)
            {
                for (int index = 0; index < files.Length; index++)
                {
                    if (!files[index].result)
                    {
                        fList.Add(files[index].filename);
                    }   
                }
            }
            return fList;
        }
    }
}
