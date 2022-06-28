using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public WeatherForecastController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult GetFromUri([System.Web.Http.FromUri] string name, [System.Web.Http.FromUri] string address)
        {
            Employee employee = new Employee();
            employee.Name = name;
            employee.Address = address;

            var serializedOutput = JsonConvert.SerializeObject(employee);
            return Ok(serializedOutput);
        }
        [HttpGet]
        public ActionResult ReadFromBody([FromBody] string title)
        {
            return Ok($"Employee Title is: {title}");
        }

        [HttpPost]
        public ActionResult ReadFromQuery(string name, string address, [FromBody]Employee employee)
        {
            return Ok($"My name is: {name} and address is: {address} and employee name is: {employee.Name} and employee address is: {employee.Address}");
        }

        [HttpGet]
        public ActionResult ReadFromHeader([FromQuery] string name, [FromHeader] string address)
        {
            return Ok($"My name is: {name} and address is: {address}");
        }

        [HttpGet("{title}/{name}/{address}")]
        public ActionResult ReadFromRoute([FromRoute] Employee employee)
        {
            return Ok($"My Title is: {employee.Title} and My name is: {employee.Name} and address is: {employee.Address}");
        }

        [HttpPost]
        public ActionResult Abhay([FromQuery] Employee employee)
        {
            employee.JoiningDate = Convert.ToDateTime(employee.JoiningDate);

            EmployeeRequest employeeRequest = new EmployeeRequest();
            employeeRequest.EmployeePersonalInfo = new Employee { Name = "Abhimanyu", Address = "Delhi" };
            employeeRequest.EducationalDetails = new EmployeeEducation { ID = 100, Marks = 50, CourseName = "MTech" };

            return Ok();
        }

        [HttpGet]
        public ActionResult ReadFromConfig()
        {
            var result = _configuration.GetSection("ConnectionStrings").GetValue<string>("MyFirstAPIContext");
            var result1 = _configuration.GetSection("Logging").GetSection("LogLevel").GetValue<string>("Default");
            var result2 = _configuration.GetSection("Logging").GetSection("LogLevel").GetValue<string>("Microsoft.AspNetCore");
            var result3 = _configuration["ResourceName"];

            return Ok($"Value of result is: {result} and Value of result1 is: {result1} and Value of result2 is: {result2}  and Value of result3 is: {result3}");
        }
    }
}