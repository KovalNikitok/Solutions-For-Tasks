using Microsoft.AspNetCore.Mvc;
using SharpTask.Models;

namespace SharpTask.Controllers
{
    [Route("api/allData")]
    [ApiController]
    public class AllDataController : ControllerBase
    {// GET: api/allData
        [HttpGet]
        public DataItem Get()
        {
            return new DataFileDeserializing().GetData();
        }
    }
}
