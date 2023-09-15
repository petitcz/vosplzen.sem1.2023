using System.ComponentModel.DataAnnotations;

namespace vosplzen.sem1h2.Data.Model
{
    public class Questionnaire
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int Rating { get; set; }

    }
}
