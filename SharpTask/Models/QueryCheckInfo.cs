using System.Collections.Generic;

namespace SharpTask.Models
{
    public class QueryCheckInfo
    {
        public QueryCheckInfo(int total,int correct,int errors, List<string> filename)
        {// Конструктор для формирования объекта класса QueryCheckInfo
            this.total = total;
            this.correct = correct;
            this.errors = errors;
            this.filename = filename;
        }
        public int total { get; set; }
        public int correct { get; set; }
        public int errors { get; set; }
        public List<string> filename { get; set; }
    }
}
