using EmployesWebApp.Models;
using System.Runtime.Serialization.Json;
using System.Text;

namespace EmployesWebApp.Repository.Implements
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository() { }
        public IConfiguration Configuration { get; }
        static HttpClient client = new HttpClient();


        public async Task<List<Employee>> GetEmployees()
        {
           return await this.GetEmployeeRequest();
        }


        public async Task<Employee> GetEmployeeById(int idEmployee)
        {
            return await this.GetEmployeeRequestById(idEmployee);
        }



        public async Task<List<Employee>> GetEmployeeRequest()
        {
            string route = "http://dummy.restapiexample.com/api/v1/employees";

            HttpResponseMessage response = await client.GetAsync(route);

            if (((int)response.StatusCode) == 429)
            {
                var time = response.Headers.GetValues("Retry-After");
                var tiempo = time.First();
                int milliseconds = (int.Parse(tiempo) + 1) * 1000;
                await Task.Delay(milliseconds);
                response = await client.GetAsync(route);
            }

            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            RequestManyEmployeers request = new RequestManyEmployeers();

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(responseContent)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(RequestManyEmployeers));
                request = (RequestManyEmployeers)deserializer.ReadObject(ms);
            }
            foreach(var item in request.data)
            {
                item.employee_salary *= 12;
            }

            return request.data;
        }

        public async Task<Employee> GetEmployeeRequestById(int idEmployee)
        {
            string route = "http://dummy.restapiexample.com/api/v1/employee/"+idEmployee;

            HttpResponseMessage response = await client.GetAsync(route);

            if (((int)response.StatusCode) == 429)
            {
                var time = response.Headers.GetValues("Retry-After");
                var tiempo = time.First();
                int milliseconds = (int.Parse(tiempo) + 1) * 1000;
                await Task.Delay(milliseconds);
                response = await client.GetAsync(route);
            }

            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            RequestOneEmployeer request = new RequestOneEmployeer();

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(responseContent)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(RequestOneEmployeer));
                request = (RequestOneEmployeer)deserializer.ReadObject(ms);
            }
            if (request.data !=null)
            {
                request.data.employee_salary *= 12;
            }
            return request.data;
        }


    }

}

