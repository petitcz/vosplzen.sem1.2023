using System.Diagnostics.Metrics;
using vosplzen.sem1h1.Model;

namespace vosplzen.sem1h1.Services
{
    public class DataProvider
    {

        public static List<Student> GetStudents(StudentFilterDto filter)
        {
            var students = InitializeStudents();
            students = OrderStudents(students, filter.OrderBy);


            if (filter.ClassFilterBy != null && filter.ClassFilterBy.Length > 0)
            {
                students = students
                  .Where(x => x.Class.Equals(filter.ClassFilterBy)).ToList();
            }

            if (!string.IsNullOrEmpty(filter.FullTextKey))
            {
                string searchText = filter.FullTextKey.ToLowerInvariant();
                students = students.Where(x =>
                    x.Lastname.ToLowerInvariant().Contains(searchText) ||
                    x.Email.ToLowerInvariant().Contains(searchText) ||
                    x.Name.ToLowerInvariant().Contains(searchText) ||
                    x.Class.ToLowerInvariant().Contains(searchText)
                ).ToList();
            }


            return students;

        }

        private static List<Student> InitializeStudents()
        {
            return new List<Student>
                {
                    new Student
                    {
                        Name = "Petr",
                        Lastname = "Boháč",
                        Email = "petr.bohac@codeclimber.cz",
                        Class = "Master"
                    },
                    new Student
                    {
                        Name = "Jaromír",
                        Lastname = "Novák",
                        Email = "jaromir.novak@escroom.cz",
                        Class = "ESC01"
                    },
                    new Student
                    {
                        Name = "Americo",
                        Lastname = "Vespucci",
                        Email = "americo.vespucci@volny.cz",
                        Class = "SPAIN01"
                    },
                    new Student
                    {
                        Name = "Marylin",
                        Lastname = "Monroe",
                        Email = "marylin.monroe@tiscalli.cz",
                        Class = "Master"
                    }
                };
        }

        private static List<Student> OrderStudents(List<Student> students, string orderBy)
        {
            switch (orderBy.ToLowerInvariant())
            {
                case "lastname":
                    return students.OrderBy(x => x.Lastname).ToList();
                case "name":
                    return students.OrderBy(x => x.Name).ToList();
                case "email":
                    return students.OrderBy(x => x.Email).ToList();
                case "class":
                    return students.OrderBy(x => x.Class).ToList();
                default:
                    return students;
            }
        }



    }
}
