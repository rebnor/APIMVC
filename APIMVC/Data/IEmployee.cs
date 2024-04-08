using APIMVC.Models;

namespace APIMVC.Data
{
    public interface IEmployee
    {
        public Task GetConnectedToAPI();

        public Task<List<Datum>> GetAllEmployees();

        public Task<Datum> GetEmployeeById(int? id);

        public Task<string> GetMessage();

    }
}
