using System.Collections.Generic;
namespace SharpTask.Models.DataInfo
{
    public class ErrorsFilesInfo
    {
        public ErrorsFilesInfo(string filename, List<string> errors)
        {// Конструктор для формирования объекта класса ErrorsFilesInfo
            this.filename = filename;
            this.errors = errors;
        }
        public string filename { get; set; }
        public List<string> errors { get; set; }

    }
}
