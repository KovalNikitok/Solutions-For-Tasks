namespace SharpTask.Models
{
    public class QueryCheckInfo
    {
        public QueryCheckInfo(int total,int correct,int errors)
        {// Конструктор для формирования объекта класса QueryCheckInfo
            this.total = total;
            this.correct = correct;
            this.errors = errors;
        }
        public int total { get; set; }
        public int correct { get; set; }
        public int errors { get; set; }
    }
}
