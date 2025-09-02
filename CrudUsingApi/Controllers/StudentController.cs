using CrudUsingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrudUsingApi.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7212/api/StudentAPI";
        private HttpClient client = new HttpClient();           
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;

            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if(data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }
    }
}
