using Microsoft.AspNetCore.Mvc;
using SharpTask.Models;
using SharpTask.Models.DataInfo;
using System.Web.Http;

namespace SharpTask.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/filenames/{result?}")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        public FilesInfo[] Get([FromUri]bool correct)
        {
            FilesInfo[] files = new DataFileDeserializing().GetData().Files;
            FilesInfo[] filesToOut = new FilesInfo[files.Length];
            int iter = 0;
            if (correct)
            {
                for (int index = 0; index < files.Length; index++)
                { 
                    if (files[index].result)
                    {
                        filesToOut[iter] = files[index];
                        iter++;
                    } 
                }
            }
            else if (!correct)
            {
                for (int index = 0; index < files.Length; index++)
                {
                    if (!files[index].result)
                    {
                        filesToOut[iter] = files[index];
                        iter++;
                    }   
                }
            }
            return filesToOut;
        }
    }
}
