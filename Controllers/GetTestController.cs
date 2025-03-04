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

    #region LINQ方式
    [HttpGet("GetList/{id}")]
    public IActionResult GetList(int id)
    {
        Person? person = getClass.Get_3().FirstOrDefault(p => p.Id == id);
        return person != null ? Ok(person) : NotFound(new { error = $"Person with ID {id} not found" });
    }

    [HttpGet("GetListById")]
    public IActionResult GetListById([FromQuery] int id)
    {
        Person? person = getClass.Get_3().FirstOrDefault(p => p.Id == id);
        return person != null ? Ok(person) : NotFound(new { error = $"Person with ID {id} not found" });
    }
    #endregion

    [HttpGet("GetListByAge")]
    public IActionResult GetListAge(string age)
    {
        List<Person> p = getClass.Get_3();
        List<Person> NewListPerson = new List<Person>();
        if (int.TryParse(age, out int a))
        {
            for (int i = p.Count - 1; i >= 0; i--)
            {
                if (p[i].Age == a)
                {
                    NewListPerson.Add(p[i]);
                }
            }
        }
        else
        {
            return BadRequest(new { error = "Invalid input" });
        }


        return Ok(NewListPerson);
    }

    [HttpGet("{age}")]
    public IActionResult GetListByAge(string age)
    {
        List<Person> p = getClass.Get_3();
        List<Person> NewListPerson = new List<Person>();
        if (int.TryParse(age, out int a))
        {
            for (int i = p.Count - 1; i >= 0; i--)
            {
                if (p[i].Age == a)
                {
                    NewListPerson.Add(p[i]);
                }
            }
        }
        else
        {
            return Challenge();
        }

        return Ok(NewListPerson);
    }

    [HttpGet("searchMore")]
    public IActionResult GetListMore([FromQuery] string id, [FromQuery] string name)
    {
        List<Person> p = getClass.Get_3();
        List<Person> NewListPerson = new List<Person>();
        if (int.TryParse(id, out int a))
        {
            for (int i = p.Count - 1; i >= 0; i--)
            {
                if (p[i].Id == a && p[i].Name == name)
                {
                    NewListPerson.Add(p[i]);
                }
            }
        }
        else
        {
            return BadRequest(new { error = "Invalid input" });
        }

        return Ok(NewListPerson);
    }

    public class SearchParams
    {
        private string _id;
        private string _age;
        public int Id
        {
            get
            {
                if (int.TryParse(_id, out int id))
                {
                    return id;
                }
                return 0;
            }
            set
            {
                _id = value.ToString();
            }
        }
        public string Name { get; set; }
        public int Age
        {
            get
            {
                if (int.TryParse(_age, out int age))
                {
                    return age;
                }
                return 0;
            }
            set
            {
                _age = value.ToString();

            }
        }
    }
    [HttpGet("searchParams")]
    public IActionResult GetListParams([FromQuery] SearchParams par)
    {
        List<Person> p = getClass.Get_3();
        List<Person> NewListPerson = new List<Person>();

        for (int i = p.Count - 1; i >= 0; i--)
        {
            if (p[i].Id == par.Id && p[i].Name == par.Name && p[i].Age == par.Age)
            {
                NewListPerson.Add(p[i]);
            }
        }

        return Ok(NewListPerson);
    }

    [HttpGet("selectParams")]
    public IActionResult GetListSelectParams(string name = "张三", int? age = 12)
    {
        List<Person> p = getClass.Get_3();
        List<Person> NewListPerson = new List<Person>();
        for (int i = p.Count - 1; i >= 0; i--)
        {
            if (p[i].Age == age && p[i].Name == name)
            {
                NewListPerson.Add(p[i]);
            }
        }

        return Ok(NewListPerson);
    }

}
