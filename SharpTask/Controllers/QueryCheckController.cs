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
        [HttpGet]
        public List<QueryCheckInfo> Get() /*QueryCheckInfo*/
        {
            FilesInfo[] data = new DataFileDeserializing().GetData().Files;
            int errors = 0, total = 0;
            string check = "query_";
            foreach(FilesInfo files in data)
            {// ищем все result, которые false и filename, начинающиеся с query_
                if (!files.result) errors++;
                if(files.filename.ToLower().StartsWith(check)) total++;
            }
            List<QueryCheckInfo> queryOut = new List<QueryCheckInfo>();
            queryOut.Add(new QueryCheckInfo(total, data.Length - errors, errors));
            return queryOut;
        }
    }
}
