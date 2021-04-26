using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SharpTask.Models;
using SharpTask.Models.DataInfo;

namespace SharpTask.Controllers
{
    [Route("api/query/check")]
    [ApiController]
    public class QueryCheckController : ControllerBase
    {
        public FilesInfo[] data = new DataFileDeserializing().GetData().Files;
        public QueryCheckInfo Transform(FilesInfo[] data)
        {// метод для преобразования данных из json файла в dto объект QueryCheckInfo
            int errors = 0, total = 0;
            string check = "query_";
            List<string> filenames = new List<string>();
            foreach (FilesInfo files in data)
            {
                {// ищем все result, которые false, и filename, начинающиеся с query_
                    if (!files.result) errors++;
                    if (files.filename.ToLower().StartsWith(check)) total++;
                    if (files.errors.Length > 0)
                        filenames.Add(files.filename);
                    //else filenames.Add(null);
                }
            }
            return new QueryCheckInfo(total, data.Length - errors, errors, filenames); //для result=true считаем вычитанием от общего количества вхождений и result=true
        }

        [HttpGet]
        public QueryCheckInfo Get()
        {
            return Transform(data); // возвращаем результат работы метода Transform
        }
    }
}
