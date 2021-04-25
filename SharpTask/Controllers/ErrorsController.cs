using Microsoft.AspNetCore.Mvc;
using SharpTask.Models;
using SharpTask.Models.DataInfo;

namespace SharpTask.Controllers
{
    [Route("api/errors/count")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {// GET: api/errors/count
        [HttpGet]
        public int Get()
        {   
            return new DataFileDeserializing().GetData().Scan.errorCount;
        }
    }
}
