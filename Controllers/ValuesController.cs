using Microsoft.AspNetCore.Mvc;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    // 定义一个路由，并设置路由名称为 "GetById"
    [HttpGet("{id?}", Name = "GetByIdA")]
    public IActionResult Get_A(int id)
    {
        return Ok($"Value with ID: {id}");
    }

    [HttpGet("Get_B/{id?}", Name = "GetByIdB")]
    public IActionResult Get_B(int id)
    {
        return Ok($"Value with ID: {id}");
    }

    [HttpGet("GetMorePar/{id?}")]
    public IActionResult GetMorePar(int? id = 3)
    {
        return Ok(123 + id);
    }
}
