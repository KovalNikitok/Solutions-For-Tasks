using Microsoft.AspNetCore.Mvc;
using SharpTask.Models;
using SharpTask.Models.DataInfo;
using System.Collections.Generic;
using System.Text;

namespace SharpTask.Controllers
{
    [Route("api/errors")]
    [ApiController]
    public class ErrorsFileController : ControllerBase
    {
        public ErrorsFilesInfo Transform(FilesInfo files)
        {// метод для преобразования полей объекта FilesInfo в ErrorsFilesInfo
            List<string> str = new List<string>();
            int iter = 0;
            foreach(ErrorsInfo errors in files.errors)
            {
                str.Add(errors.error);
                iter++;
            }
            return new ErrorsFilesInfo(files.filename, str);
        }
        public FilesInfo[] files = new DataFileDeserializing().GetData().Files;// Получаем десериализованный Json в объект FilesInfo[]

        [HttpGet]
        public List<ErrorsFilesInfo> Get()
        {
            List<ErrorsFilesInfo> filesOut = new List<ErrorsFilesInfo>();// Список для формирования ответа*
            for (int index = 0; index < files.Length; index++)
            {
                if (!files[index].result)
                {// условие в рамках запроса
                    filesOut.Add(Transform(files[index]));
                }
            }
            return filesOut;
        }

        [HttpGet("{index}")]
        public List<ErrorsFilesInfo> Get(int index)
        {
            List<ErrorsFilesInfo> filesOut = new List<ErrorsFilesInfo>();
            int count = 0;
            for (int iter = 0; iter < files.Length; iter++)
            {
                if (!files[iter].result)
                {
                    filesOut.Add(Transform(files[iter]));
                    count++;
                }
            }
            if (index < count && index >= 0)
            {// уловие для отбора по индексу 
                return filesOut.GetRange(index, 1);
            }
            else return null;
        }
    }
}
