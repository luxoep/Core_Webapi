using Microsoft.AspNetCore.Mvc;
using _Get_Class;
using Person_Class;


namespace WebApiCSharp.Controllers.GetWebapi;

[ApiController]
[Route("api/[controller]")]
public class GetTestController : ControllerBase
{
    GetClass getClass = new GetClass();

    [HttpGet("GetStr")]
    public string GetMain1()
    {
        return getClass.Get_1();
    }
    [HttpGet("GetList")]
    public ActionResult<List<Person>> GetList()
    {
        Dictionary<string, List<Person>> p1 = new Dictionary<string, List<Person>>()
        {
            {"person1",getClass.Get_3()}
        };
        return Ok(p1);
    }
    [Route("GetOneRowPerson")]
    [HttpGet()]
    public ActionResult<Person> GetOnePerson()
    {
        Person person = new Person(3, "何七", 34, '女');
        return Ok(person);
    }
    [HttpGet("GetList/{id}")]
    public IActionResult GetListById(int id)
    {
        var person = getClass.Get_3().FirstOrDefault(p => p.Id == id);
        return person != null ? Ok(person) : NotFound(new { error = $"Person with ID {id} not found" });
    }

    [HttpGet("GetListById")]
    public IActionResult GetList([FromQuery] int id)
    {
        var person = getClass.Get_3().FirstOrDefault(p => p.Id == id);
        return person != null ? Ok(person) : NotFound(new { error = $"Person with ID {id} not found" });
    }
}
