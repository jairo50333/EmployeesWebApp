namespace EmployesWebApp.Models
{
    public class RequestManyEmployeers : RequestHttp
    {
        public List<Employee> data { get; set; } = new List<Employee>();
    }
}
