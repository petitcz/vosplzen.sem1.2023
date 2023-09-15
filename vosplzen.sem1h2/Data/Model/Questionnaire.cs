using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace vosplzen.sem1h2.Data.Model
{
    public class Questionnaire
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Jméno")]
        [Required(ErrorMessage = "Toto pole je povinné"), MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Příjmení")]
        [Required(ErrorMessage = "Toto pole je povinné"), MaxLength(30)]
        public string Surname { get; set; }

        [DisplayName("Hodnocení")]
        [Required(ErrorMessage = "Toto pole je povinné")]
        public int Rating { get; set; }

        [DisplayName("Vytvořeno")]
        public DateTime Created { get; set; }

        [DisplayName("Celé jméno")]
        public string FullName
        {
            get { return $"{Surname} {Name}"; }

        }
    }

}
