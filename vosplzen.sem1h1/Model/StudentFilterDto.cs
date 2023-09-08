namespace vosplzen.sem1h1.Model
{
    public class StudentFilterDto
    {
        public string OrderBy { get; set; } = string.Empty;

        public string FullTextKey { get; set; } = string.Empty;

        public string ClassFilterBy { get; set; } = string.Empty;

        public bool IsOn
        {
            get
            {

                return (ClassFilterBy != null && ClassFilterBy.Length > 0) || (FullTextKey != null && FullTextKey.Length > 0);

            }
        }

    }
}
