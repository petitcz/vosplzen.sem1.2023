using vosplzen.sem1h3.Data.Model;

namespace vosplzen.sem1h3.Services.Interfaces
{
    public interface IDataService
    {
        Task CreateNewProfile();

        Task<List<Student>> GetData();

        Task DeleteStudent(int id);
    }
}
