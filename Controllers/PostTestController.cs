using Microsoft.AspNetCore.Mvc;
using Student_Class;
using PostClass;
using Newtonsoft.Json.Linq;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostTestController : ControllerBase
{

    [HttpPost("AddOne")]
    public IActionResult AddOne([FromBody] string name)
    {
        if (name == null) return BadRequest(new { error = "Invalid input" });

        List<Student> students = new _Post().Post_Add(name, 12, "女");

        Dictionary<string, object> newStu = new Dictionary<string, object>();

        foreach (Student item in students)
        {
            if (item.Name == name)
            {
                newStu.Add("name", item.Name);
                newStu.Add("age", item.Age);
                newStu.Add("gender", item.Gender);
                return Ok(newStu);
            }
        }

        return BadRequest(new { error = "未找到新加项目" });
    }


    [HttpPost("AddPerson")]
    public IActionResult AddPerson([FromBody] Student s)
    {
        if (s != null)
        {
            string? name = s.Name;
            int age = s.Age;
            string gender = s.Gender;

            _Post post = new _Post();
            List<Student> newPerson = post.Post_Add(name, age, gender);

            return Ok(newPerson);
        }

        return BadRequest(new { error = "Invalid input" });
    }

    [HttpPost("AddPerson_A")]
    public IActionResult AddPerson_A([FromBody] Student s)
    {
        if (s != null)
        {
            _Post post = new _Post();
            List<Student> newPerson = post.Post_Add_A(s);

            return Ok(newPerson);
        }

        return BadRequest(new { error = "Invalid input" });
    }

    [HttpPost("AddPerson_B")]
    public IActionResult AddPerson_B([FromBody] Student s)
    {
        if (s != null)
        {
            _Post post = new _Post();
            Student newPerson = post.Post_Add_B(s);

            return Ok(newPerson);
        }

        return BadRequest(new { error = "Invalid input" });
    }
}
