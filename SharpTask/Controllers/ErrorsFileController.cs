using Microsoft.AspNetCore.Mvc;
using SharpTask.Models;
using SharpTask.Models.DataInfo;

namespace SharpTask.Controllers
{
    [Route("api/errors")]
    [ApiController]
    public class ErrorsFileController : ControllerBase
    {
        public FilesInfo[] files = new DataFileDeserializing().GetData().Files;
        [HttpGet]
        public ErrorsFilesInfo[] Get()
        {
            FilesInfo[] filesToOut = new FilesInfo[files.Length];
            int iter = 0;
                for (int index = 0; index < files.Length; index++)
                {
                    if (!files[index].result)
                    {
                        filesToOut[iter] = files[index];
                        iter++;
                    }
                }
            ErrorsFilesInfo[] errorsFiles = (ErrorsFilesInfo[])filesToOut.Clone();
            return errorsFiles;
        }
    }
}
