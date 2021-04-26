namespace SharpTask.Models.DataInfo
{
    public class ErrorsFilesInfo
    {
        public ErrorsFilesInfo(string filename, ErrorsInfo[] errors)
        {// Конструктор для формирования объекта
            this.filename = filename;
            this.errors = errors;
        }

        public string filename { get; set; }
        public ErrorsInfo[] errors { get; set; }

    }
}
