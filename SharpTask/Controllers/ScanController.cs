using Microsoft.AspNetCore.Mvc;
using SharpTask.Models;
using SharpTask.Models.DataInfo;

namespace SharpTask.Controllers
{
    [Route("api/scan")]
    [ApiController]
    public class ScanController : ControllerBase
    {// GET: api/scan
        [HttpGet]
        public ScanInfo Get()
        {
            return new DataFileDeserializing().GetData().Scan;
        }
    }
}
