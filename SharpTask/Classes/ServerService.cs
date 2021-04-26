
using SharpTask.Models.DataInfo;
using System;

namespace SharpTask.Models
{
    public class ServerService
    {
        public ServiceInfo getServiceInfo()
        {// формирование объекта на основе методов снизу
            ServiceInfo service = new ServiceInfo();
            service.Version = getVersion();
            service.AppName = getAssemblyName();
            service.DateUtc = getDateTime();
            return service;
        }
        // методы для получения данных проекта
        private string getAssemblyName()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        }
        private string getVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        private DateTime getDateTime()
        {
            return DateTime.Now;
        }
    }
}
