using Microsoft.AspNetCore.Mvc;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SomeOtherController : ControllerBase
{
    // 通过路由名称动态生成 URL
    [HttpGet]
    public IActionResult GetLink()
    {
        // 使用路由名称 "GetById" 和参数 { id = 123 } 生成 URL
        var url = Url.Link("GetById", new { id = 123 });
        if (url == null)
        {
            return NotFound("URL not found");
        }
        return Ok(url); // 返回生成的 URL
    }
}
