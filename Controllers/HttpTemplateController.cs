using Microsoft.AspNetCore.Mvc;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HttpTemplateController : ControllerBase
{
    // 不使用Http模板命名，默认请求路径就为 api/HttpTemplate
    [HttpGet]
    [HttpGet("GetNotRouteTemp")]
    [HttpGet("{id}")]
    public IActionResult GetNotRouteTemp(int id)
    {
        if (id != 0) return Ok(id);
        return Ok("Get not route template");
    }

}

[ApiController]
public class NotControllerHttpTemplateController : ControllerBase
{
    [HttpGet("NotControllerHttpTemplate/GetNotRouteTemp")]
    [HttpGet("NotControllerHttpTemplate/{id}")]
    public IActionResult GetNotRouteTemp_A(int id)
    {
        if (id != 0) return Ok(id);
        return Ok("Get not route template");
    }
    [HttpGet("GetNotRouteTemp")]
    [HttpGet("{id}")]
    public IActionResult GetNotRouteTemp_B(int id)
    {
        if (id != 0) return Ok(id);
        return Ok("Get not route template");
    }

}
