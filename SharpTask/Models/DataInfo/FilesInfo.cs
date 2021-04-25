using System;

namespace SharpTask.Models.DataInfo
{
    public class FilesInfo
    {
        public string filename { get; set; }
        public bool result { get; set; }
        public ErrorsInfo[] errors { get; set; }
        public DateTime scantime { get; set; }
    }
}
