using IRouteTemplateProviderTest;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Route("api/account")]
public class ValuesController : ControllerBase
{
    #region 3_1~3-4
    // 定义一个路由，并设置路由名称为 "GetById"
    // [HttpGet("{id?}", Name = "GetByIdA")]
    // public IActionResult Get_A(int id)
    // {
    //     return Ok($"Value with ID: {id}");
    // }

    // [HttpGet("Get_B/{id?}", Name = "GetByIdB")]
    // public IActionResult Get_B(int id)
    // {
    //     return Ok($"Value with ID: {id}");
    // }

    [HttpGet("GetMorePar/{id?}")]
    public IActionResult GetMorePar(int? id = 3)
    {
        return Ok(123 + id);
    }
    #endregion

    #region 3_5
    [HttpGet("GetRoute_A/{id}")]
    public IActionResult GetRoute_A(string id)
    {
        return Ok(id);
    }
    [HttpGet("GetRoute_B/{id:int}")]
    public IActionResult GetRoute_B(string id)
    {
        return Ok(id);
    }
    [HttpGet("GetRoute_C/{id:max(10)}")]
    public IActionResult GetRoute_C(string id)
    {
        return Ok(id);
    }
    [HttpGet("GetRoute_D/{id:int:max(10)}")]
    public IActionResult GetRoute_D(string id)
    {
        return Ok(id);
    }
    [HttpGet("{phoneNumber:phone}")]
    public IActionResult GetPhone(string phoneNumber)
    {
        return Ok($"Phone number: {phoneNumber}");
    }

    #endregion

    #region 3_6
    [HttpGet]
    [HttpGet("More")]
    [HttpGet("MoreTemp")]
    [HttpGet("MoreTemp/{id}")]
    public IActionResult MoreTemp(int id = 0)
    {
        if (id == 0) return Ok("多模板_A");
        return Ok("多模板_B");
    }
    #endregion

}


#region 3_7
[MyIRouteTemplateProvider]
public class WatchPhoneController : ControllerBase
{
    [HttpGet("Test")]
    public IActionResult MyRoute()
    {
        return Ok("我的路由");
    }
}

[MyIRouteTemplateProvider(Prefix = "User")]
public class WatchController : ControllerBase
{
    [HttpGet("Test")]
    public IActionResult MyRoute()
    {
        return Ok("我的路由");
    }
}
#endregion 
