using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace vosplzen.sem1h3.Data.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] ImageBlob { get; set; }

        public string ImageBase64
        {
            get
            {
                string base64Image = Convert.ToBase64String(ImageBlob);
                string imageSrc = $"data:image/png;base64,{base64Image}";
                return imageSrc;
            }
        }
    }


}
