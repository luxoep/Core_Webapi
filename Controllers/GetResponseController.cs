using Microsoft.AspNetCore.Mvc;

namespace WebApiCSharp.Controllers.Webapi_2_1;

[ApiController]
[Route("api/[controller]")]
public class GetResponseController : ControllerBase
{

    #region 日志记录工具
    // private readonly ILogger<GetResponseController> _logger;

    // public GetResponseController(ILogger<GetResponseController> logger)
    // {
    //     _logger = logger;
    // }
    #endregion

    [HttpGet("GetStr")]
    public Dictionary<string, object> GetStr()
    {
        Person p = new Person();
        p.Name = "三三";
        p.Age = 12;
        p.Gender = '女';
        return p.UserRes();
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public char Gender { get; set; }
    public Person() { }
    public Person(string name, int age, char gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }
    public Dictionary<string, object> UserRes()
    {
        return new Dictionary<string, object>()
        {
            {"name", Name},
            {"age", Age},
            {"gender", Gender}
        };
    }
}