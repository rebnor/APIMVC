using APIMVC.Models;
using NuGet.Packaging;
using System.Text.Json;

namespace APIMVC.Data
{
    public class EmployeeRepository : IEmployee
    {

        private List<Datum> employees = new List<Datum>();

        public async Task GetConnectedToAPI()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://reqres.in/api/users?page=2");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var employee = JsonSerializer.Deserialize<Employee>(result);

                foreach (var item in employee.data)
                {
                    item.message = await GetMessage();
                    employees.Add(item);
                }

            }
        }

        public async Task<List<Datum>> GetAllEmployees()
        {
            await GetConnectedToAPI();
            return employees;
        }

        public async Task<Datum> GetEmployeeById(int? id)
        {
            await GetConnectedToAPI();
            var theEmployee = employees.FirstOrDefault(d => d.id == id);
            return theEmployee;
        }

        public async Task<string> GetMessage()
        {
            Message message = new Message();
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://techy-api.vercel.app/api/json");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                message = JsonSerializer.Deserialize<Message>(result);

                return message.message;
            }
            else
            {
                return "";
            }
        }
    }
}
