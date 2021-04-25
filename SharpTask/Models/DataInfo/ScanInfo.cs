using System;
namespace SharpTask.Models.DataInfo
{
    public class ScanInfo
    {
        public DateTime scanTime { get; set; }
        public string db { get; set; }
        public string server { get; set; }
        public int errorCount { get; set; }
    }
}
