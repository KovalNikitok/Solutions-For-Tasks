using System;
using Microsoft.AspNetCore.Mvc;
using SharpTask.Models;
using SharpTask.Models.DataInfo;

namespace SharpTask.Controllers
{
    [Route("api/service/serviceInfo")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        public ServiceInfo ServiceOutput()
        {// вызываем метод созданного класса для получения объекта с данными о проекте
            ServerService service = new ServerService();
            return service.getServiceInfo();
        }


    }
}
