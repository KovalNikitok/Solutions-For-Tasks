using SharpTask.Models.DataInfo;

namespace SharpTask.Models
{
    public class DataItem
    {
        public ScanInfo Scan { get; set; }
        public FilesInfo[] Files { get; set; }
    }
}
