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
        public List<FilesInfo> Get([FromUri]bool correct)
        {
            FilesInfo[] files = new DataFileDeserializing().GetData().Files;
            List<FilesInfo> fList = new List<FilesInfo>();
            int iter = 0;
            if (correct)
            {
                for (int index = 0; index < files.Length; index++)
                { 
                    if (files[index].result)
                    {
                        fList.Add(files[index]);
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
                        fList.Add(files[index]);
                        iter++;
                    }   
                }
            }
            return fList;
        }
    }
}
